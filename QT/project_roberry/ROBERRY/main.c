#include <stdio.h>
#include <stdlib.h>
#include <roberry.h>

int main()
{
    printf("Привет!\n"
           "Начнем играть или нужна помошь?\n\n"
           "1. Играем\n"
           "2. Нужна помощь\n");

    // проверка ввода
    int start;
    int mistake = 1;

    do{
        scanf("%d", &start);                                   // !!!!!!!проверка на символ!!!!!!!!!!!!
        if(start != 1 && start != 2)
            printf("Внимательнее! Попробуй еще раз.\n");
        else
            mistake = 0;
    } while(mistake);

    system("/usr/bin/clear");

    switch (start){
    case 2:
        printf("Правила игры: ...\n");
        break;
    case 1:

        // *************************************************************************************************
        printf("");
        Field game_field[BUILDINGS];

        int gold[GOLD_CARD] = {8,30,9,17,19,28,29,13,20,31,16,11,22,7,10,27,32,34,6,33,5,25,15,36,14,2,23,24,21,26,18,4,12,3,1,35};
        int g = 0;  // индекс для сокровищ

        Score your_score;
        Score apponent_score;

        // обнуление счета
        your_score.gold.red = your_score.gold.yellow = your_score.gold.green = your_score.gold.blue = 0;
        your_score.cache.red = your_score.cache.yellow = your_score.cache.green = your_score.cache.blue = 0;
        your_score.total = 0;
        apponent_score.gold.red = apponent_score.gold.yellow = apponent_score.gold.green = apponent_score.gold.blue = 0;
        apponent_score.cache.red = apponent_score.cache.yellow = apponent_score.cache.green = apponent_score.cache.blue = 0;
        apponent_score.total = 0;

        // обнуляем и заполняем сокровищами, стартовый вариант
        for(int i = 0; i < BUILDINGS; ++i)
        {
            game_field[i].informer = 0;
            game_field[i].place = i + 1;
            game_field[i].jewel = gold[g++];
            game_field[i].burglar = 0;
        }

        int resume = 1;
        do
        {
            show_field(game_field);

            game_field[3].burglar = 2;
            you_assign(game_field); // назначение

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
                            apponent_score = scoring_gold(game_field[i].jewel, apponent_score); // аппонент получает добычу
                        game_field[i].jewel = 0;
                    }
                    else
                    {
                        // игроки получают тайник
                        your_score = scoring_cache(your_score);
                        apponent_score = scoring_cache(apponent_score);
                    }
                }
            }

            score_results(your_score, apponent_score);

            printf("Продолжаем?\n"
                   "1. Да\n"
                   "2. Нет\n");
            scanf("%d", &resume);

            // восстановление поля
            for(int i = 0; i < BUILDINGS; ++i)
            {
                game_field[i].informer = 0;
                if(game_field[i].jewel == 0)
                    game_field[i].jewel = gold[g++];
                game_field[i].burglar = 0;
            }
            system("/usr/bin/clear");
        }while(resume == 1);


        // **************************************************************************************************

        break;
    }
    printf("Всего доброго!\n");
    return 0;
}
