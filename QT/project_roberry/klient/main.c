#include <stdio.h>
#include <stdlib.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
#include <string.h>
#include <../ROBERRY/roberry.h>

int main(int argc, char **argv)
{
    if(argc != 2)
    {
        write(2, "have to write adress\n", 21);
        return 1;
    }

    // натсройка
    int aSocket = socket(AF_INET, SOCK_STREAM, 0);
    if(aSocket < 0)
    {
        write(2, "Error: socket\n", 11);
        return 1;
    }

    int error;
    struct sockaddr_in peer;

    peer.sin_family = AF_INET;
    peer.sin_port = htons(7500); // ona preobrazobybaet k setevomu poryadku bait
    // peer.sin_addr.s_addr = inet_addr("127.0.0.1"); // 127.0.0.1 - eto my sami, nash komp
    peer.sin_addr.s_addr = inet_addr(argv[1]);

    error = connect(aSocket, (struct sockaddr *) &peer, sizeof(peer));
    if(error)
    {
        write(2, "ER: connect\n", 12);
        return 1;
    }

    // поехали
    system("/usr/bin/clear");
    printf("Привет!\n"
           "Начнем играть или нужна помошь?\n\n");
    int exit = 0;
    while(!exit)
    {
        int choise;
        printf("1. Играем\n"
               "2. Правила игры\n"
               "3. Выход\n");
        scanf("%d", &choise);

        system("/usr/bin/clear");

        switch (choise)
        {
            case 3:
                exit = 1;
                break;
            case 2:
                printf("Правила игры: ...\n\n");
                printf("1. Назад\n"
                       "2. Выход\n");
                int tmp;
                scanf("%d", &tmp);
                if(tmp == 2)
                    exit = 1;
                system("/usr/bin/clear");
                break;
            case 1:
                system("/usr/bin/clear");
                int new_game = 1;
                while(new_game)
                {
                    Field game_field[BUILDINGS];
                    int gold[GOLD_CARD];
                    int g = 0;  // индекс для сокровищ

                    for(int i = 0; i < GOLD_CARD; ++i)
                        gold[i] = i + 1;
                    swap_array(gold, GOLD_CARD);

                    Score your_score;
                    Score opponent_score;

                    // обнуление счета
                    your_score.gold.red = your_score.gold.yellow = your_score.gold.green = your_score.gold.blue = 0;
                    your_score.cache.red = your_score.cache.yellow = your_score.cache.green = your_score.cache.blue = 0;
                    your_score.total = 0;
                    opponent_score.gold.red = opponent_score.gold.yellow = opponent_score.gold.green = opponent_score.gold.blue = 0;
                    opponent_score.cache.red = opponent_score.cache.yellow = opponent_score.cache.green = opponent_score.cache.blue = 0;
                    opponent_score.total = 0;

                    // расставляем места, стартовый вариант
                    for(int i = 0; i < BUILDINGS; ++i)
                    {
                        game_field[i].place = i + 1;
                        game_field[i].jewel = gold[g++];
                    }

                    // для передачи
                    int buf_jewel[BUILDINGS] = {0};
                    int buf_informer[BUILDINGS] = {0};
                    int buf_burgular[BUILDINGS] = {0};
                    int buf_total_opp[5] = {0}; // количество цветов плюс бонусы
                    int buf_total_you[5] = {0}; // количество цветов плюс бонусы

                    int resume = 1; // для продолжения или выхода из игры

                    while(resume == 1)
                    {
                        int i = 0; // для проверки на конец колоды

                        // восстановление поля
                        for(i; i < BUILDINGS && g <= GOLD_CARD; ++i)
                        {
                            game_field[i].informer = 0;
                            if(game_field[i].jewel == 0)
                                game_field[i].jewel = gold[g++];
                            game_field[i].burglar = 0;
                        }

                        if(i != BUILDINGS) // говорит о том, что карт оказалось недостаточно
                        {
                            // послать сообщение что игра закончена
                            error = write(aSocket, "over\n", 5);
                            if(error <= 0)
                            {
                                write(2, "ER: write\n", 10);
                                return 1;
                            }

                            //переход к подсчету балов

                            your_score = scoring_total(your_score);

                            // принимаем балы соперника

                            error = read(aSocket, buf_total_opp, 5 * sizeof(int));
                            if(error <= 0)
                            {
                                write(2, "ER: read\n", 9);
                                return 1;
                            }
                            else
                            {
                                int tmp = strcmp(buf_total_opp, "exit\n");
                                if(!tmp)
                                {
                                    system("/usr/bin/clear");
                                    error = write(1, "Второй участник покинул игру.\n", 55);
                                    return 0;
                                }
                            }

                            // перевод балов соперника
                            opponent_score.gold.red = buf_total_opp[0];
                            opponent_score.gold.yellow = buf_total_opp[1];
                            opponent_score.gold.green = buf_total_opp[2];
                            opponent_score.gold.blue = buf_total_opp[3];
                            opponent_score.total = buf_total_opp[4];

                            // отправляем свои
                            buf_total_you[0] = your_score.gold.red;
                            buf_total_you[1] = your_score.gold.yellow;
                            buf_total_you[2] = your_score.gold.green;
                            buf_total_you[3] = your_score.gold.blue;
                            buf_total_you[4] = your_score.total;

                            error = write(aSocket, buf_total_you, 5 * sizeof(int));
                            if(error <= 0)
                            {
                                write(2, "ER: write\n", 10);
                                return 1;
                            }

                            // считаем победителя
                            if(your_score.gold.blue != opponent_score.gold.blue)
                            {
                                if(your_score.gold.blue > opponent_score.gold.blue)
                                    your_score.total += 4;
                                else
                                    opponent_score.total += 4;
                            }


                            if(your_score.gold.green != opponent_score.gold.green)
                            {
                                if(your_score.gold.green > opponent_score.gold.green)
                                    your_score.total += 3;
                                else
                                    opponent_score.total += 3;
                            }

                            if(your_score.gold.red != opponent_score.gold.red)
                            {
                                if(your_score.gold.red > opponent_score.gold.red)
                                    your_score.total += 3;
                                else
                                    opponent_score.total += 3;
                            }

                            if(your_score.gold.yellow != opponent_score.gold.yellow)
                            {
                                if(your_score.gold.yellow > opponent_score.gold.yellow)
                                    your_score.total += 2;
                                else
                                    opponent_score.total += 2;
                            }

                            if(your_score.total != opponent_score.total)
                            {
                                if(your_score.total > opponent_score.total)
                                    printf("ВЫ ПОБЕДИЛИ!!!\n"
                                           "Поздравляем!\n");
                                else
                                    printf("ВЫ ПРОИГРАЛИ...\n");
                            }
                            else
                                printf("ПОБЕДИЛА ДРУЖБА!\n"
                                       "Вы набрали одинаковое количество баллов.\n");

                            show_game_results(your_score, opponent_score);

                            printf("Еще играем?\n\n"
                                   "1. Да\n"
                                   "2. Выход\n");
                            int tmp;
                            scanf("%d", &tmp);
                            system("/usr/bin/clear");
                            if(tmp == 2)
                            {
                                new_game = 0;
                                printf("Вы уверены, что хотите выйти?\n\n");
                            }
                            resume = 2;
                        }
                        else // карт достаточно
                        {
                            // отправляем сокровища
                            for(int i = 0; i < BUILDINGS; ++i)
                                buf_jewel[i] = game_field[i].jewel;
                            error = write(aSocket, buf_jewel, BUILDINGS * sizeof(int));
                            if(error <= 0)
                            {
                                write(2, "ER: write\n", 10);
                                return 1;
                            }

                            show_field(game_field);

                            you_assign(game_field); // назначение

                            //принять выбор
                            error = read(aSocket, buf_informer, BUILDINGS * sizeof(int));
                            if(error <= 0)
                            {
                                write(2, "ER: read\n", 9);
                                return 1;
                            }
                            else
                            {
                                int tmp = strcmp(buf_informer, "exit\n");
                                if(!tmp)
                                {
                                    system("/usr/bin/clear");
                                    error = write(1, "Второй участник покинул игру.\n", 55);
                                    return 0;
                                }
                            }

                            error = read(aSocket, buf_burgular, BUILDINGS * sizeof(int));
                            if(error <= 0)
                            {
                                write(2, "ER: read\n", 9);
                                return 1;
                            }
                            else
                            {
                                int tmp = strcmp(buf_burgular, "exit\n");
                                if(!tmp)
                                {
                                    system("/usr/bin/clear");
                                    error = write(1, "Второй участник покинул игру.\n", 55);
                                    return 0;
                                }
                            }

                            //сложить поля
                            for(int i = 0; i < BUILDINGS; ++i)
                            {
                                game_field[i].informer += buf_informer[i];
                                game_field[i].burglar += buf_burgular[i];
                            }

                            // отправляем результат
                            for(int i = 0; i < BUILDINGS; ++i)
                            {
                                buf_informer[i] = game_field[i].informer;
                                buf_burgular[i] = game_field[i].burglar;
                            }
                            error = write(aSocket, buf_informer, BUILDINGS * sizeof(int));
                            if(error <= 0)
                            {
                                write(2, "ER: write\n", 10);
                                return 1;
                            }
                            error = write(aSocket, buf_burgular, BUILDINGS * sizeof(int));
                            if(error <= 0)
                            {
                                write(2, "ER: write\n", 10);
                                return 1;
                            }

                            system("/usr/bin/clear");

                            show_field(game_field);

                            // разбор полетов
                            for(int i = 0; i < BUILDINGS; ++i)
                            {
                                if(game_field[i].informer == 0)
                                {
                                    if(game_field[i].burglar != 3)
                                    {
                                        if(game_field[i].burglar == 1)
                                            your_score = scoring_gold(game_field[i].jewel, your_score); // вы получаете добычу
                                        else if(game_field[i].burglar == 2)
                                            opponent_score = scoring_gold(game_field[i].jewel, opponent_score); // аппонент получает добычу
                                        game_field[i].jewel = 0;
                                    }
                                    else
                                    {
                                        // игроки получают тайник
                                        your_score = scoring_cache(your_score);
                                        opponent_score = scoring_cache(opponent_score);
                                    }
                                }
                            }

                            show_score_results(your_score, opponent_score);

                            printf("Продолжаем?\n"
                                   "1. Да\n"
                                   "2. Нет\n");
                            scanf("%d", &resume);
                            if(resume == 2)
                                new_game = 0;

                            system("/usr/bin/clear");

                        } // конец else
                    } // конец while(resume == 1);
                } // конец while(new_game)
                break;
        } // конец switch(choise)
    } // конец while(exit)

    // сообщаем оппоненту об уходе
    error = write(aSocket, "exit\n", 5);
    if(error <= 0)
    {
        write(2, "ER: write\n", 10);
        return 1;
    }

    printf("Всего доброго!\n");
    return 0;
}
