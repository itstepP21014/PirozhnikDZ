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
    if (SDL_Init(SDL_INIT_EVERYTHING) == -1){
        printf("SDL_GetError(): SDL_Init\n");
        return 1;
    }

    SDL_Window *win = NULL;
    SDL_Renderer *ren = NULL;
    win = SDL_CreateWindow("ОГРАБЛЕНИЕ ПО...", SDL_WINDOWPOS_CENTERED,
        SDL_WINDOWPOS_CENTERED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN);
    if (!win){
        printf("SDL_GetError(): CreateWindow\n");
        return 2;
    }
    ren = SDL_CreateRenderer(win, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);
    if (!ren){
        printf("SDL_GetError(): CreateRenderer\n");
        return 3;
    }
/*
    // загружаем текст
    TTF_Font* font = TTF_OpenFont("Old Comedy.ttf", 24);
    if(font == NULL)
    {
        printf("Unable to load font: %s \n", TTF_GetError());
        return false;
    }
    SDL_Color fore_color = {255, 0, 0, 255};
    //SDL_Color back_color = { BLUE_COLOR };
*/
    // загружаем картинки и заносим в массив текстур
    SDL_Texture *pictures[35];
    int i = 0;

    //SDL_Texture *background = LoadImage("bg.bmp");
    //    *pictures[i++] = &background; //0

    SDL_Texture *background = LoadImage("../img/empty.jpg", ren);
        pictures[i++] = background; //0
    SDL_Texture *cache = LoadImage("../img/cache.jpg", ren);
        pictures[i++] = cache; //1
    SDL_Texture *goldBlue = LoadImage("../img/goldBlue.jpg", ren);
        pictures[i++] = goldBlue; //2
    SDL_Texture *goldGreen = LoadImage("../img/goldGreen.jpg", ren);
        pictures[i++] = goldGreen; //3
    SDL_Texture *goldRed = LoadImage("../img/goldRed.jpg", ren);
        pictures[i++] = goldRed; //4
    SDL_Texture *goldYellow = LoadImage("../img/goldYellow.jpg", ren);
        pictures[i++] = goldYellow; //5
    SDL_Texture *score = LoadImage("../img/score.jpg", ren);
        pictures[i++] = score; //6
    SDL_Texture *empty = LoadImage("../img/empty.jpg", ren);
        pictures[i++] = empty; //7
    SDL_Texture *placeA = LoadImage("../img/placeA.jpg", ren);
        pictures[i++] = placeA; //8
    SDL_Texture *placeB = LoadImage("../img/placeB.jpg", ren);
        pictures[i++] = placeB; //9
    SDL_Texture *placeC = LoadImage("../img/placeC.jpg", ren);
        pictures[i++] = placeC; //10
    SDL_Texture *placeD = LoadImage("../img/placeD.jpg", ren);
        pictures[i++] = placeD; //11
    SDL_Texture *placeE = LoadImage("../img/placeE.jpg", ren);
        pictures[i++] = placeE; //12
    SDL_Texture *gamer1 = LoadImage("../img/gamer1.jpg", ren);
        pictures[i++] = gamer1; //13
    SDL_Texture *gamer2 = LoadImage("../img/gamer2.jpg", ren);
        pictures[i++] = gamer2; //14
    SDL_Texture *gamerBoth = LoadImage("../img/gamerBoth.jpg", ren);
        pictures[i++] = gamerBoth; //15
    SDL_Texture *bonus1 = LoadImage("../img/bonus1.jpg", ren);
        pictures[i++] = bonus1; //16
    SDL_Texture *bonus2 = LoadImage("../img/bonus2.jpg", ren);
        pictures[i++] = bonus2; //17
    SDL_Texture *random = LoadImage("../img/random.jpg", ren);
        pictures[i++] = random; //18
    SDL_Texture *any = LoadImage("../img/any.jpg", ren);
        pictures[i++] = any; //19
    SDL_Texture *color = LoadImage("../img/color.jpg", ren);
        pictures[i++] = color; //20
    SDL_Texture *blue2 = LoadImage("../img/blue2.jpg", ren);
        pictures[i++] = blue2; //21
    SDL_Texture *blue3 = LoadImage("../img/blue3.jpg", ren);
        pictures[i++] = blue3; //22
    SDL_Texture *blue4 = LoadImage("../img/blue4.jpg", ren);
        pictures[i++] = blue4; //23
    SDL_Texture *blue5 = LoadImage("../img/blue5.jpg", ren);
        pictures[i++] = blue5; //24
    SDL_Texture *green2 = LoadImage("../img/green2.jpg", ren);
        pictures[i++] = green2; //25
    SDL_Texture *green3 = LoadImage("../img/green3.jpg", ren);
        pictures[i++] = green3; //26
    SDL_Texture *green4 = LoadImage("../img/green4.jpg", ren);
        pictures[i++] = green4; //27
    SDL_Texture *green5 = LoadImage("../img/green5.jpg", ren);
        pictures[i++] = green5; //28
    SDL_Texture *red2 = LoadImage("../img/red2.jpg", ren);
        pictures[i++] = red2; //29
    SDL_Texture *red3 = LoadImage("../img/red3.jpg", ren);
        pictures[i++] = red3; //30
    SDL_Texture *red4 = LoadImage("../img/red4.jpg", ren);
        pictures[i++] = red4; //31
    SDL_Texture *red5 = LoadImage("../img/red5.jpg", ren);
        pictures[i++] = red5; //32
    SDL_Texture *yellow2 = LoadImage("../img/../img/yellow2.jpg", ren);
        pictures[i++] = yellow2; //33
    SDL_Texture *yellow3 = LoadImage("../img/yellow3.jpg", ren);
        pictures[i++] = yellow3; //34
    SDL_Texture *yellow4 = LoadImage("../img/yellow4.jpg", ren);
        pictures[i++] = yellow4; //35
    SDL_Texture *yellow5 = LoadImage("../img/yellow5.jpg", ren);
        pictures[i++] = yellow5; //36

    for(int i = 0; i < ALL_PICTURES; ++i)
    {
        if (pictures[i] == NULL)
            return 4;
    }

    // поехали **********************************************************************************
/*
    // приветственное окно - только текст, ждет выбор
    //_________________________________________________________________________________________
    SDL_RenderClear(ren);
    SDL_Surface* first_surf = TTF_RenderText_Solid(font, "Приветствую! 1Играем, 2правила, 3выходим?", fore_color);
    if(first_surf == NULL)
    {
        printf("Unable to load textsurface: %s \n", SDL_GetError());
        return false;
    }
    SDL_Rect first_loc = { 20, 0, 300, 50 };
    ApplyTextSurface(first_surf, ren, first_loc);
    SDL_RenderPresent(ren);
    */
    //_______________________________________________________________________________________

    SDL_Event event;
    bool exit = false;
    while (!exit)
    {
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
                    /*
                        // ПРАВИЛА
                        //__________________________________________________________________________

                        SDL_RenderClear(ren);
                        SDL_Surface* ruls_surf = TTF_RenderText_Solid(font, "ПРАВИЛА ИГРЫ. 1Назад 2Выход", fore_color);
                        if(ruls_surf == NULL)
                        {
                            printf("Unable to load textsurface: %s \n", SDL_GetError());
                            return false;
                        }
                        SDL_Rect ruls_loc = { 20, 0, 300, 50 };
                        ApplyTextSurface(ruls_surf, ren, ruls_loc);
                        SDL_RenderPresent(ren);
                        */
                        //_________________________________________________________________________________

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
                                    case SDLK_1:
                                    {
                                        exit = true; // назад
                                        break;
                                    }
                                    case SDLK_2:
                                    {
                                        exit = true;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                        // КОНЕЦ ПРАВИЛ
                    case SDLK_1:
                    {
                        // ИГРА

                        int new_game = 1;
                        while(new_game)
                        {
                            int field[FIELD_STR][FIELD_CLM] = {{0}}; // игровое поле

                            int your_score[GOLD_STR][GOLD_CLM] = {{0}};
                            int opponent_score[GOLD_STR][GOLD_CLM] = {{0}};
                            int your_total = 0;
                            int opponent_total = 0;

                            // расставляем места кражи, мeняться не будет
                            fill_place(field);

                            int resume = 1; // для продолжения или выхода из игры
                            while(resume == 1)
                            {

                                // принимаем сокровища
                                int buf_jewel[FIELD_CLM] = {0};
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
                                            scoring_total(your_score);

                                            // отправить баллы
                                            error = write(aSocket, your_total, 1);
                                            if(error <= 0)
                                            {
                                                write(2, "ER: write\n", 10);
                                                return 1;
                                            }

                                            // принять балы соперника
                                            error = read(aSocket, opponent_total, 1);
                                            if(error <= 0)
                                            {
                                                write(2, "ER: read\n", 9);
                                                return 1;
                                            }
                                            else
                                            {
                                                int tmp = strcmp(opponent_total, "exit\n");
                                                if(!tmp)
                                                {
                                                    system("/usr/bin/clear");
                                                    error = write(1, "Второй участник покинул игру.\n", 55);
                                                    return 0;
                                                }
                                            }

                                            // считаем победителя
                                            your_total = check_total(your_score, opponent_score, your_total);

                                            int winner = check_winner(your_total, opponent_total);

                                            switch(winner)
                                            {
                                                case 0:
                                                {
                                                /*
                                                    //______________________________________________________________________________________
                                                    SDL_RenderClear(ren);
                                                    char buf[258];
                                                    sprintf(buf, "НИЧЬЯ...%d...", your_score[GOLD][GREEN]);
                                                    SDL_Surface* bothWin_surf = TTF_RenderText_Solid(font, buf, fore_color);
                                                    if(bothWin_surf == NULL)
                                                    {
                                                        printf("Unable to load textsurface: %s \n", SDL_GetError());
                                                        return false;
                                                    }
                                                    SDL_Rect bothWin_loc = { 20, 0, 300, 50 };
                                                    ApplyTextSurface(bothWin_surf, ren, bothWin_loc);
                                                    SDL_RenderPresent(ren);
                                                    */
                                                    //__________________________________________________________________________________________
                                                    break;
                                                }
                                                case 1:
                                                {
                                                /*
                                                    //______________________________________________________________________________________
                                                    SDL_RenderClear(ren);
                                                    char buf[258];
                                                    sprintf(buf, "ВЫ ВЫЙГРАЛИ!!!...%d...", your_score[GOLD][GREEN]);
                                                    SDL_Surface* youWin_surf = TTF_RenderText_Solid(font, buf, fore_color);
                                                    if(youWin_surf == NULL)
                                                    {
                                                        printf("Unable to load textsurface: %s \n", SDL_GetError());
                                                        return false;
                                                    }
                                                    SDL_Rect youWin_loc = { 20, 0, 300, 50 };
                                                    ApplyTextSurface(youWin_surf, ren, youWin_loc);
                                                    SDL_RenderPresent(ren);
                                                    */
                                                    //____________________________________________________________________
                                                }
                                                case 2:
                                                {
                                                /*
                                                    //______________________________________________________________________________________
                                                    SDL_RenderClear(ren);
                                                    char buf[258];
                                                    sprintf(buf, "ВЫ ПРОИГРАЛИ (((...%d...", your_score[GOLD][GREEN]);
                                                    SDL_Surface* youLost_surf = TTF_RenderText_Solid(font, buf, fore_color);
                                                    if(youLost_surf == NULL)
                                                    {
                                                        printf("Unable to load textsurface: %s \n", SDL_GetError());
                                                        return false;
                                                    }
                                                    SDL_Rect youLost_loc = { 20, 0, 300, 50 };
                                                    ApplyTextSurface(youLost_surf, ren, youLost_loc);
                                                    SDL_RenderPresent(ren);
                                                    */
                                                    //____________________________________________________________________
                                                    break;
                                                }
                                            }

                                            bool done = false;
                                            while(!done) // для проверки на правильность ввода
                                            {
                                                done = true; // предполагаем что пользователь ввел правильно
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
                                                            case SDLK_1:
                                                            {
                                                                resume = 2;
                                                                break;
                                                            }
                                                            case SDLK_2:
                                                            {
                                                                resume = 2;
                                                                new_game = 0;
                                                                break;
                                                            }
                                                            default:
                                                            {
                                                                done = false;
                                                                break;
                                                            }
                                                        } //switch
                                                    } //case
                                                } //switch
                                            } //while done last
                                        }
                                        else // карт достаточно
                                        {
                                            // складываем (этакая функция восстановления)
                                            for(int i = 0; i < FIELD_CLM; ++i)
                                            {
                                                field[JEWEL][i] = buf_jewel[i];
                                            }

                                            // экран меняется на игровое поле и ждет выбор информаторов и воров
                                            SDL_RenderClear(ren);
                                            //картинка
                                            Show_field(field, pictures, ren);
                                            /*
                                            // текст____________________________________________________________________
                                            SDL_Surface* game_surf = TTF_RenderText_Solid(font, "кого грабим, что защищаем?", fore_color);
                                            if(game_surf == NULL)
                                            {
                                                printf("Unable to load textsurface: %s \n", SDL_GetError());
                                                return false;
                                            }
                                            SDL_Rect game_loc = { 0, 0, 300, 50 };
                                            ApplyTextSurface(game_surf, ren, game_loc);
                                            */
                                            SDL_RenderPresent(ren);
                                            //__________________________________________________________________________

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
                                            int buf_informer[FIELD_CLM] = {0};
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

                                            int buf_burgular[FIELD_CLM] = {0};
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
                                            for(int i = 0; i < FIELD_CLM; ++i)
                                            {
                                                if(field[INFORM][i] == 0)
                                                {
                                                    if(field[BURG][i] != 3)
                                                    {
                                                        if(field[BURG][i] == 1)
                                                            scoring_gold(field[JEWEL][i], your_score, your_total); // вы получаете добычу
                                                        else if(field[BURG][i] == 2)
                                                            scoring_gold(field[JEWEL][i], opponent_score, opponent_total); // аппонент получает добычу
                                                        field[JEWEL][i] = 0;
                                                    }
                                                    else
                                                    {
                                                        // игроки получают тайник
                                                        scoring_cache(your_score[CACHE]);
                                                        scoring_cache(opponent_score[CACHE]);
                                                    }
                                                }
                                            }

                                            // обновляется поле, текст теперь с результатами и ждет продолжения
                                            SDL_RenderClear(ren);
                                            // картинка
                                            Show_field(field, pictures, ren);
/*
                                            // текст__________________________________________________________________-
                                            char buf[258];
                                            sprintf(buf, "текущ результаты...%d...", your_score[GOLD][GREEN]);
                                            SDL_Surface* result_surf = TTF_RenderText_Solid(font, buf, fore_color);
                                            if(result_surf == NULL)
                                            {
                                                printf("Unable to load textsurface: %s \n", SDL_GetError());
                                                return false;
                                            }
                                            SDL_Rect result_loc = { 0, 0, 300, 50 };
                                            ApplyTextSurface(result_surf, ren, result_loc);
                                            */
                                            SDL_RenderPresent(ren);
                                            //_______________________________________________________________________
                                            SDL_RenderPresent(ren);

                                            chose_continue(exit, new_game);

                                        } // else карт достаточно
                                    } //else
                                } // else
                            } //while resume
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
    /*
    //__________________________________________________________________________
    SDL_RenderClear(ren);
    SDL_Surface* bye_surf = TTF_RenderText_Solid(font, "Пока!", fore_color);
    if(bye_surf == NULL)
    {
        printf("Unable to load textsurface: %s \n", SDL_GetError());
        return false;
    }
    SDL_Rect bye_loc = { 0, 0, 300, 50 };
    ApplyTextSurface(bye_surf, ren, bye_loc);
    SDL_RenderPresent(ren);
    */
    //_________________________________________________________________________
    SDL_Delay(1000);

    for(int i = 0; i < ALL_PICTURES; ++i)
        SDL_DestroyTexture(pictures[i]);
    // все текстуры текста
//    TTF_CloseFont(font);
    SDL_DestroyRenderer(ren);
    SDL_DestroyWindow(win);
    SDL_Quit();

    printf("Exited cleanly\n");
    return 0;
}
