#include <stdio.h>
#include <stdlib.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
#include <string.h>
#include <../lib/roberry_p.h>
#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include <SDL2/SDL_image.h>

int main()
{
    //настройка сервера
    int listenSocket = socket(AF_INET, SOCK_STREAM, 0);
    if(listenSocket < 0)
    {
        write(2, "Error: socket\n", 14);
        return 1;
    }

    int error;
    struct sockaddr_in local;

    local.sin_family = AF_INET;
    local.sin_port = htons(7500);
    local.sin_addr.s_addr = htonl(INADDR_ANY);

    error = bind(listenSocket, (struct sockaddr *) &local, sizeof(local));
    if(error)
    {
        write(2, "ER: bind\n", 9);
        return 1;
    }

    error = listen(listenSocket, 5);
    if(error)
    {
        write(2, "ER: listen\n", 11);
        return 1;
    }

    int aSocket = accept(listenSocket, NULL, NULL);
    if(aSocket < 0)
    {
        write(2, "ER: accept\n", 11);
        return 1;
    }

    //SDL
    if (SDL_Init(SDL_INIT_EVERYTHING) == -1)
    {
        printf("SDL_GetError(): SDL_Init\n");
        return 1;
    }
    SDL_Window *win = SDL_CreateWindow("ОГРАБЛЕНИЕ ПО...", SDL_WINDOWPOS_CENTERED,
        SDL_WINDOWPOS_CENTERED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN);
    if (!win)
    {
        printf("SDL_GetError(): CreateWindow\n");
        return 2;
    }
    SDL_Renderer *ren = SDL_CreateRenderer(win, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);
    if (!ren)
    {
        printf("SDL_GetError(): CreateRenderer\n");
        return 3;
    }
    if (TTF_Init() == -1)
    {
        printf("TTF_GetError(): TTF_Init\n");
        return 4;
    }
    TTF_Font* font = TTF_OpenFont("Old Comedy.ttf", 24);
    if(font == NULL)
    {
        printf("TTF_GetError(): TTF_OpenFont\n");
        return 5;
    }
    SDL_Color font_color = {255, 255, 255, 255};

    SDL_Rect CardsRect = { 220, 40, 0, 0 };

    // загружаем картинки и заносим в массив текстур
    SDL_Texture* *pictures = (SDL_Texture**)malloc(ALL_PICTURES * sizeof(SDL_Texture**));
      for(int i = 0; i < ALL_PICTURES; ++i)
    {
        pictures[i] = (SDL_Texture*)malloc(sizeof(SDL_Texture*));

    }

    SDL_Texture *empty = LoadImage("../img/empty.jpg", ren);
        pictures[EMPTY] = empty;
    SDL_Texture *cache = LoadImage("../img/cache.jpg", ren);
        pictures[CACHE_R] = cache;
    SDL_Texture *goldBlue = LoadImage("../img/goldBlue.jpg", ren);
        pictures[CACHE_BLUE] = goldBlue;
    SDL_Texture *goldGreen = LoadImage("../img/goldGreen.jpg", ren);
        pictures[CACHE_GREEN] = goldGreen;
    SDL_Texture *goldRed = LoadImage("../img/goldRed.jpg", ren);
        pictures[CACHE_RED] = goldRed;
    SDL_Texture *goldYellow = LoadImage("../img/goldYellow.jpg", ren);
        pictures[CACHE_YELLOW] = goldYellow;
    SDL_Texture *score = LoadImage("../img/score.jpg", ren);
        pictures[SCORE_l] = score;
    SDL_Texture *placeA = LoadImage("../img/a.jpg", ren);
        pictures[PLACE_A] = placeA;
    SDL_Texture *placeB = LoadImage("../img/b.jpg", ren);
        pictures[PLACE_B] = placeB;
    SDL_Texture *placeC = LoadImage("../img/c.jpg", ren);
        pictures[PLACE_C] = placeC;
    SDL_Texture *placeD = LoadImage("../img/d.jpg", ren);
        pictures[PLACE_D] = placeD;
    SDL_Texture *placeE = LoadImage("../img/e.jpg", ren);
        pictures[PLACE_E] = placeE;
    SDL_Texture *gamer1 = LoadImage("../img/gamer1.jpg", ren);
        pictures[GAMER1] = gamer1;
    SDL_Texture *gamer2 = LoadImage("../img/gamer2.jpg", ren);
        pictures[GAMER2] = gamer2;
    SDL_Texture *gamerBoth = LoadImage("../img/gamerBoth.jpg", ren);
        pictures[GAMER_BOTH] = gamerBoth;
    SDL_Texture *bonus1 = LoadImage("../img/bonus1.jpg", ren);
        pictures[BONUS1] = bonus1;
    SDL_Texture *bonus2 = LoadImage("../img/bonus2.jpg", ren);
        pictures[BONUS2] = bonus2;
    SDL_Texture *random = LoadImage("../img/random.jpg", ren);
        pictures[RANDOM] = random;
    SDL_Texture *any = LoadImage("../img/any.jpg", ren);
        pictures[ANY] = any;
    SDL_Texture *color = LoadImage("../img/../img/color.jpg", ren);
        pictures[COLOR] = color;
    SDL_Texture *blue2 = LoadImage("../img/blue2.jpg", ren);
        pictures[BLUE2] = blue2;
    SDL_Texture *blue3 = LoadImage("../img/blue3.jpg", ren);
        pictures[BLUE3] = blue3;
    SDL_Texture *blue4 = LoadImage("../img/blue4.jpg", ren);
        pictures[BLUE4] = blue4;
    SDL_Texture *blue5 = LoadImage("../img/blue5.jpg", ren);
        pictures[BLUE5] = blue5;
    SDL_Texture *green2 = LoadImage("../img/green2.jpg", ren);
        pictures[GREEN2] = green2;
    SDL_Texture *green3 = LoadImage("../img/green3.jpg", ren);
        pictures[GREEN3] = green3;
    SDL_Texture *green4 = LoadImage("../img/green4.jpg", ren);
        pictures[GREEN4] = green4;
    SDL_Texture *green5 = LoadImage("../img/green5.jpg", ren);
        pictures[GREEN5] = green5;
    SDL_Texture *red2 = LoadImage("../img/red2.jpg", ren);
        pictures[RED2] = red2;
    SDL_Texture *red3 = LoadImage("../img/red3.jpg", ren);
        pictures[RED3] = red3;
    SDL_Texture *red4 = LoadImage("../img/red4.jpg", ren);
        pictures[RED4] = red4;
    SDL_Texture *red5 = LoadImage("../img/red5.jpg", ren);
        pictures[RED5] = red5;
    SDL_Texture *yellow2 = LoadImage("../img/yellow2.jpg", ren);
        pictures[YELLOW2] = yellow2;
    SDL_Texture *yellow3 = LoadImage("../img/yellow3.jpg", ren);
        pictures[YELLOW3] = yellow3;
    SDL_Texture *yellow4 = LoadImage("../img/yellow4.jpg", ren);
        pictures[YELLOW4] = yellow4;
    SDL_Texture *yellow5 = LoadImage("../img/yellow5.jpg", ren);
        pictures[YELLOW5] = yellow5;

    // ******ПОЕХАЛИ**********************************************************************************

    // ____приветственное окно _______________________________________________________________________

    SDL_RenderClear(ren);

    SDL_Event event;
    bool exit = false;
    while (!exit)
    {
        // фон
        SDL_RenderCopy(ren, pictures[EMPTY], NULL, NULL);

        SDL_Texture* wlcm = LoadText("Приветствую!", font, font_color, ren);
        SDL_Rect wlcm_loc = { 20, 20, 120, 20 };
        SDL_RenderCopy(ren, wlcm, NULL, &wlcm_loc);

        SDL_Texture* wlcm_qst = LoadText("Будем играть или нужна помощь?", font, font_color, ren);
        SDL_Rect wlcm_qst_loc = { 20, 45, 300, 20 };
        SDL_RenderCopy(ren, wlcm_qst, NULL, &wlcm_qst_loc);

        SDL_Texture* wlcm_pl = LoadText("1. Играть", font, font_color, ren);
        SDL_Rect wlcm_pl_loc = { 20, 80, 90, 20 };
        SDL_RenderCopy(ren, wlcm_pl, NULL, &wlcm_pl_loc);

        SDL_Texture* wlcm_rls = LoadText("2. Правила игры", font, font_color, ren);
        SDL_Rect wlcm_rls_loc = { 20, 105, 150, 20 };
        SDL_RenderCopy(ren, wlcm_rls, NULL, &wlcm_rls_loc);

        SDL_Texture* wlcm_ext = LoadText("3. Выход", font, font_color, ren);
        SDL_Rect wlcm_ext_loc = { 20, 130, 90, 20 };
        SDL_RenderCopy(ren, wlcm_ext, NULL, &wlcm_ext_loc);

        SDL_RenderPresent(ren);
    //_______________________________________________________________________________________

        SDL_WaitEvent(&event);
        switch(event.type)
        {
            case SDL_QUIT:
            {
                exit = true;
                break;
            }
            case SDL_KEYDOWN:
            {
                switch(event.key.keysym.sym)
                {
                    case SDLK_ESCAPE:
                    {
                        exit = true;
                        break;
                    }
                    case SDLK_3:
                    {
                        exit = true;
                        break;
                    }
                    case SDLK_2:
                    {

                        //____правила______________________________________________________________________
                        SDL_RenderClear(ren);

                        //фон
                        SDL_RenderCopy(ren, pictures[EMPTY], NULL, NULL);

                        ApplayRules(font, font_color, ren);

                        SDL_RenderPresent(ren);
                        //_________________________________________________________________________________

                        chose_back(exit);
                        break;
                    }
                    case SDLK_1:
                    {
                        // ИГРА

                        int new_game = 1;
                        while(new_game)
                        {
                            //игровое поле
                            int **field = (int**)malloc(FIELD_STR * sizeof(int*));
                            if(field == NULL)
                                printf("Error: get memmory/n");
                            for(int i = 0; i < FIELD_STR; ++i)
                            {
                                field[i] = (int*)malloc(FIELD_CLM * sizeof(int));
                                if(field[i] == NULL)
                                    printf("Error: get memmory/n");
                            }

                            // очки
                            int **your_score = (int**)malloc(GOLD_STR * sizeof(int*));
                            if(your_score == NULL)
                                printf("Error: get memmory/n");
                            for(int i = 0; i < GOLD_STR; ++i)
                            {
                                your_score[i] = (int*)malloc(GOLD_CLM * sizeof(int));
                                if(your_score[i] == NULL)
                                    printf("Error: get memmory/n");
                            }

                            int **opponent_score = (int**)malloc(GOLD_STR * sizeof(int*));
                            if(opponent_score == NULL)
                                printf("Error: get memmory/n");
                            for(int i = 0; i < GOLD_STR; ++i)
                            {
                                opponent_score[i] = (int*)malloc(GOLD_CLM * sizeof(int));
                                if(opponent_score[i] == NULL)
                                    printf("Error: get memmory/n");
                            }

                            int your_total = 0;
                            int opponent_total = 0;

                            // расставляем места кражи, мeняться не будет
                            fill_place(field);

                            int resume = 1; // для продолжения или выхода из игры
                            while(resume == 1)
                            {

                                // принимаем сокровища
                                char buf_jewel[FIELD_CLM] = {0};
                                error = read(aSocket, buf_jewel, FIELD_CLM * sizeof(int));
                                if(error <= 0)
                                {
                                    write(2, "ER: read\n", 9);
                                    return 1;
                                }
                                else
                                {
                                    int tmp = strcmp(buf_jewel, "exit\n");
                                    if(!tmp)
                                    {
                                        system("/usr/bin/clear");
                                        error = write(1, "Второй участник покинул игру.\n", 55);
                                        return 0;
                                    }
                                    else
                                    {
                                        int tmp = strcmp(buf_jewel, "over\n");
                                        if(!tmp)
                                        {
                                            //переход к подсчету балов
                                            sum_score(your_score);

                                            // отправить баллы
                                            error = write(aSocket, &your_total, sizeof(int));
                                            if(error <= 0)
                                            {
                                                write(2, "ER: write\n", 10);
                                                return 1;
                                            }

                                            // принять балы соперника
                                            char buf_opponent_total[1];
                                            error = read(aSocket, buf_opponent_total, sizeof(int));
                                            if(error <= 0)
                                            {
                                                write(2, "ER: read\n", 9);
                                                return 1;
                                            }
                                            else
                                            {
                                                int tmp = strcmp(buf_opponent_total, "exit\n");
                                                if(!tmp)
                                                {
                                                    system("/usr/bin/clear");
                                                    error = write(1, "Второй участник покинул игру.\n", 55);
                                                    return 0;
                                                }
                                            }
                                            opponent_total = buf_opponent_total[0];

                                            // считаем победителя
                                            your_total = check_total(your_score, opponent_score, your_total);

                                            int winner = check_winner(your_total, opponent_total);

                                            switch(winner)
                                            {
                                                case 0:
                                                {
                                                    //______________________________________________________________________________________
                                                    SDL_RenderClear(ren);

                                                    //фон
                                                    SDL_RenderCopy(ren, pictures[EMPTY], NULL, NULL);

                                                    ApplayResults("ПОБЕДИЛА ДРУЖБА! :)", 190, font, font_color,ren,
                                                                your_score, opponent_score, your_total, opponent_total);

                                                    SDL_RenderPresent(ren);
                                                    //__________________________________________________________________________________________
                                                    break;
                                                }
                                                case 1:
                                                {
                                                    //______________________________________________________________________________________
                                                    SDL_RenderClear(ren);

                                                    //фон
                                                    SDL_RenderCopy(ren, pictures[EMPTY], NULL, NULL);

                                                    ApplayResults("ВЫ ВЫЙГРАЛИ!!! Поздравляем.", 270, font, font_color,ren,
                                                                your_score, opponent_score, your_total, opponent_total);

                                                    SDL_RenderPresent(ren);
                                                    //____________________________________________________________________
                                                }
                                                case 2:
                                                {
                                                    //______________________________________________________________________________________
                                                    SDL_RenderClear(ren);

                                                    //фон
                                                    SDL_RenderCopy(ren, pictures[EMPTY], NULL, NULL);

                                                    ApplayResults("ВЫ ПРОИГРАЛИ... :(", 180, font, font_color,ren,
                                                                your_score, opponent_score, your_total, opponent_total);

                                                    SDL_RenderPresent(ren);
                                                    //____________________________________________________________________
                                                    break;
                                                }
                                            }

                                            choise_again(exit, resume, new_game);
                                        }
                                        else // карт достаточно
                                        {
                                            // складываем (этакая функция восстановления)
                                            for(int i = 0; i < FIELD_CLM; ++i)
                                            {
                                                field[JEWEL][i] = buf_jewel[i];
                                            }

                                            // показ игрового поля
                                            // ____________________________________________________________________
                                            SDL_RenderClear(ren);

                                            //картинка
                                            ShowField(ren, field, pictures, CardsRect);
                                            //текст
                                            ApplayChoise(font, font_color, ren);

                                            SDL_RenderPresent(ren);
                                            //_________________________________________________________________________

                                            //выбор информаторов
                                            chose_informer(field, exit);

                                            // выбор воров
                                            chose_burgular(field, exit);

                                            // отправляем выбор
                                            error = write(aSocket, (char*)field[INFORM], FIELD_CLM * sizeof(int));
                                            if(error <= 0)
                                            {
                                                write(2, "ER: write\n", 10);
                                                return 1;
                                            }
                                            error = write(aSocket, (char*)field[BURG], FIELD_CLM * sizeof(int));
                                            if(error <= 0)
                                            {
                                                write(2, "ER: write\n", 10);
                                                return 1;
                                            }

                                            //получили результат выбора соперника
                                            char buf_informer[FIELD_CLM];
                                            error = read(aSocket, buf_informer, FIELD_CLM * sizeof(int));
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

                                            char buf_burgular[FIELD_CLM];
                                            error = read(aSocket, buf_burgular, FIELD_CLM * sizeof(int));
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

                                            // заполняем результаты
                                            for(int i = 0; i < FIELD_CLM; ++i)
                                            {
                                               field[INFORM][i] =  buf_informer[i];
                                               field[BURG][i] =  buf_burgular[i];
                                            }

                                            // разбор полетов
                                            get_prize(field, your_score, opponent_score, your_total, opponent_total);

                                            // результататы раунда
                                            //__________________________________________________________________
                                            SDL_RenderClear(ren);

                                            // картинка
                                            ShowField(ren, field, pictures, CardsRect);
                                            // текст
                                            ApplayRound(font, font_color, ren, your_score, opponent_score, your_total, opponent_total);
                                            SDL_RenderPresent(ren);
                                            //_______________________________________________________________________

                                            chose_continue(exit, new_game);

                                        } //else карт достаточно
                                    } //else
                                } // else
                            } //while resume
                            free(field);
                            field = NULL;
                            free(your_score);
                            your_score = NULL;
                            free(opponent_score);
                            opponent_score = NULL;
                        } //while new_game
                        //КОНЕЦ ИГРЫ
                        break;
                    } // case
                } //switch
                break;
            } //case
        } //switch
    } //while exit
    // сообщаем оппоненту об уходе
    error = write(aSocket, "exit\n", 5);
    if(error <= 0)
    {
        write(2, "ER: write\n", 10);
        return 1;
    }
    //окно обновляется на прощальное
    //__________________________________________________________________________
    SDL_RenderClear(ren);

    //фон
    SDL_RenderCopy(ren, pictures[EMPTY], NULL, NULL);

    SDL_Texture* bye = LoadText("ВСЕГО ДОБРОГО!", font, font_color, ren);
    SDL_Rect bye_loc = { 400, 305, 400, 45 };
    SDL_RenderCopy(ren, bye, NULL, &bye_loc);

    SDL_RenderPresent(ren);
    //_________________________________________________________________________
    SDL_Delay(2000);

    //чистимся
    for(int i = 0; i < ALL_PICTURES; ++i)
        SDL_DestroyTexture(pictures[i]);
    // удалить все текстуры текста...
    free(pictures);
    pictures = NULL;
    TTF_CloseFont(font);
    SDL_DestroyRenderer(ren);
    SDL_DestroyWindow(win);
    SDL_Quit();

    printf("Exited cleanly\n");
    return 0;
}
