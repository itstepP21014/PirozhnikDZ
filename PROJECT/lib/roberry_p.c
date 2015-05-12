#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <../roberry_p.h>
#include <SDL2/SDL.h>
#include <SDL/SDL_ttf.h>
#include <SDL2/SDL_image.h>

void fill_place(int **field)
{
    for(int i = 0; i < FIELD_CLM; ++i)
        field[PLACE][i] = i; // возможно и + 1
}

bool restore_field(int **field, int *gold, int index)
{
    int i = 0;
    for(i; i < FIELD_STR && index <= GOLD_CARD; ++i)
    {
        field[INFORM][i] = 0;
        if(field[JEWEL][i] == 0)
            field[JEWEL][i] = gold[index++];
        field[BURG][i] = 0;
    }
    if(i != FIELD_STR)
        return false;
    else
        return true;
}

void scoring_total(int **score)
{
    for(int i =0; i < GOLD_STR; ++i)
        score[GOLD][i] += score[CACHE][i];
}

int check_total(int **you, int **opponent, int total)
{
    if(you[GOLD][BLUE] > opponent[GOLD][BLUE])
        total += 4;

    if(you[GOLD][GREEN] > opponent[GOLD][GREEN])
        total += 3;

    if(you[GOLD][RED] > opponent[GOLD][RED])
        total += 3;

    if(you[GOLD][YELLOW] > opponent[GOLD][YELLOW])
        total += 2;

    return total;
}

int check_winner(int you, int opponent)
{
    if(you != opponent)
    {
        if(you > opponent)
            return 1; // вы победили
        else
            return 2; //вы проиграли
    }
    else
        return 0; // ничья
}


void scoring_gold(const int n, int **score, int total)
{
    switch(n){
    case 1: case 2: case 3: case 4:
    {
        for(int i = 0; i < GOLD_CLM; ++i )
            score[GOLD][i] += 1;
    }
        break;
    case 5:
        score[GOLD][RED] += 2;
        break;
    case 6: case 7:
        score[GOLD][RED] += 3;
        break;
    case 8: case 9:
        score[GOLD][RED] += 4;
        break;
    case 10:
        score[GOLD][RED] += 5;
        break;
    case 11:
        score[GOLD][YELLOW] += 2;
        break;
    case 12: case 13:
        score[GOLD][YELLOW] += 3;
        break;
    case 14: case 15:
        score[GOLD][YELLOW] += 4;
        break;
    case 16:
        score[GOLD][YELLOW] += 5;
        break;
    case 17:
        score[GOLD][GREEN] += 2;
        break;
    case 18: case 19:
        score[GOLD][GREEN] += 3;
        break;
    case 20: case 21:
        score[GOLD][GREEN] += 4;
        break;
    case 22:
        score[GOLD][GREEN] += 5;
        break;
    case 23:
        score[GOLD][BLUE] += 2;
        break;
    case 24: case 25:
        score[GOLD][BLUE] += 3;
        break;
    case 26: case 27:
        score[GOLD][BLUE] += 4;
        break;
    case 28:
        score[GOLD][BLUE] += 5;
        break;
    case 29: case 30: case 31:
        total += 1;
        break;
    case 32:
        total += 2;
        break;
    case 33: case 34:
        for(int i = 0; i < 3; ++i)
        {
            srand(time(NULL));
            int tmp = rand() % 4 + 1;
            switch(tmp){
            case 1:
                score[GOLD][RED] += 1;
                break;
            case 2:
                score[GOLD][YELLOW] += 1;
                break;
            case 3:
                score[GOLD][GREEN] += 1;
                break;
            case 4:
                score[GOLD][BLUE] += 1;
                break;
            }
        }
        break;
    case 35: case 36:
        for(int i = 0; i < 3; ++i)
            scoring_cache(score[CACHE]);
        break;
    }
}

void scoring_cache(int *score) // передаем score[CACHE][]
{
    srand(time(NULL));
    int tmp = rand() % 4 + 1;
    switch(tmp){
    case 1:
        score[RED] += 1;
        break;
    case 2:
        score[YELLOW] += 1;
        break;
    case 3:
        score[GREEN] += 1;
        break;
    case 4:
        score[BLUE] += 1;
        break;
    }
}

void chose_informer(int **field, bool exit)
{
    SDL_Event event;
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
                    case SDLK_1: case SDLK_a:
                    {
                        field[INFORM][A] += 1;
                        break;
                    }
                    case SDLK_2: case SDLK_b:
                    {
                        field[INFORM][B] += 1;
                        break;
                    }
                    case SDLK_3: case SDLK_c:
                    {
                        field[INFORM][C] += 1;
                        break;
                    }
                    case SDLK_4: case SDLK_d:
                    {
                        field[INFORM][D] += 1;
                        break;
                    }
                    case SDLK_5: case SDLK_e:
                    {
                        field[INFORM][E] += 1;
                        break;
                    }
                    default:
                    {
                        done = false; // пользователь ошибся при вводе
                        break;
                    }
                }
            }
        }
    }
}

void chose_burgular(int **field, bool exit)
{
    SDL_Event event;
    bool done = false;
    while(!done) // для проверки на правильность ввода
    {
        done = true; // предполагаем что пользователь ввел правильно
        SDL_WaitEvent(&event);
        switch(event.type)
        {
            case SDL_QUIT:
            {
                done = true;
                exit = true;
                break;
            }
            case SDL_KEYDOWN:
            {
                switch(event.key.keysym.sym)
                {
                    case SDLK_ESCAPE:
                    {
                        done = true;
                        exit = true;
                        break;
                    }
                    case SDLK_1: case SDLK_a:
                    {
                        field[BURG][A] += 1;
                        break;
                    }
                    case SDLK_2: case SDLK_b:
                    {
                        field[BURG][B] += 1;
                        break;
                    }
                    case SDLK_3: case SDLK_c:
                    {
                        field[BURG][C] += 1;
                        break;
                    }
                    case SDLK_4: case SDLK_d:
                    {
                        field[BURG][D] += 1;
                        break;
                    }
                    case SDLK_5: case SDLK_e:
                    {
                        field[BURG][E] += 1;
                        break;
                    }
                    default:
                    {
                        done = false; // пользователь ошибся при вводе
                        break;

                    }
                }
            }
        }
    }
}

void chose_continue(bool exit, int new_game)
{
    SDL_Event event;
    bool done = false;
    while(!done) // для проверки на правильность ввода
    {
        done = true; // предполагаем что пользователь ввел правильно
        SDL_WaitEvent(&event);
        switch(event.type)
        {
            case SDL_QUIT:
            {
                done = true;
                exit = true;
                break;
            }
            case SDL_KEYDOWN:
            {
                switch(event.key.keysym.sym)
                {
                    case SDLK_ESCAPE:
                    {
                        done = true;
                        exit = true;
                        break;
                    }
                    case SDLK_1:
                    {

                        break;
                    }
                    case SDLK_2:
                    {
                        new_game = 0;
                        break;
                    }
                    default:
                    {
                        done = false;
                        break;
                    }
                }
            }
        }
    }
}

/*
void show_score_results(const Score a, const Score b)
{
    printf("\nВАШ СЧЕТ:\n");
    printf("Красных: %d (%d)\n", a.gold.red, a.cache.red);
    printf("Желтых: %d (%d)\n", a.gold.yellow, a.cache.yellow);
    printf("Зеленых: %d (%d)\n", a.gold.green, a.cache.green);
    printf("Синих: %d (%d)\n", a.gold.blue, a.cache.blue);
    printf("БОНУСЫ: %d\n", a.total);
    printf("\n");
    printf("СЧЕТ ОППОНЕНТА:\n");
    printf("Красных: %d\n", b.gold.red);
    printf("Желтых: %d\n", b.gold.yellow);
    printf("Зеленых: %d\n", b.gold.green);
    printf("Синих: %d\n", b.gold.blue);
    printf("/В тайнике/: %d\n", b.cache.red + b.cache.yellow + b.cache.green + b.cache.blue);
    printf("БОНУСЫ: %d\n", b.total);
    printf("\n");
}

void show_game_results(const Score a, const Score b)
{
  printf("\n                     У ВАС    У СОПЕРНИКА:\n");
    printf("Синих:              %2d       %2d\n", a.gold.blue, b.gold.blue);
    printf("Зеленых:            %2d       %2d\n", a.gold.green, b.gold.green);
    printf("Красных:            %2d       %2d\n", a.gold.red, b.gold.red);
    printf("Желтых:             %2d       %2d\n", a.gold.yellow, b.gold.yellow);
    printf("-------------------------------\n");
    printf("Итого с бонусами:   %2d       %2d\n", a.total, b.total);
    printf("\n");
}
*/

void swap_array(int *array, int size)
{
    srand(time(NULL));
    for(int i = 0; i < size; ++i)
        array[i] = i+1;

    for(int i = size; i > 0; --i)
    {
        for (int k = 0; k < i; ++k)
        {
            int a = rand() % i;
            int b = rand() % i;
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}

//SDL___________________________________________________________________________

SDL_Texture* LoadImage(const char *file, SDL_Renderer *ren)
{
    SDL_Surface *img = IMG_Load(file);
    if(img == NULL)
    {
        fprintf(stderr, "IMG_Load Error: %s\n", SDL_GetError());
        exit(1);
    }
    SDL_Texture *tex = SDL_CreateTextureFromSurface(ren, img);
    SDL_FreeSurface(img);
    if(tex == NULL)
    {
        fprintf(stderr, "SDL_CreateTextureFromSurface Error: %s\n", SDL_GetError());
        exit(1);
    }
    return tex;
}

void ApplySurface(int x, int y, int w, int h, SDL_Texture *tex, SDL_Renderer *ren)
{
   SDL_Rect pos;
   pos.x = x;
   pos.y = y;
   SDL_QueryTexture(tex, NULL, NULL, &w, &h);
   SDL_RenderCopy(ren, tex, NULL, &pos);
}

void DrawInform(const SDL_Texture **pic, const int *mas, SDL_Renderer *renderer)
{
    for(int i = 0; i < FIELD_CLM; ++i)
    {
        int x = CARD_X + i * CARD_W;
        switch(mas[i])
        {
        case 1:
            ApplySurface(x, CARD_Y, CARD_W, CARD_H, pic[13], renderer); // gam1
            break;
        case 2:
            ApplySurface(x, CARD_Y, CARD_W, CARD_H, pic[14], renderer); // gam2
            break;
        case 3:
            ApplySurface(x, CARD_Y, CARD_W, CARD_H, pic[15], renderer); // gamBoth
            break;
        case 0:
            ApplySurface(x, CARD_Y, CARD_W, CARD_H, pic[7], renderer); // empty
            break;
        default:
            break;
        }
    }
}

void DrawBurg(const SDL_Texture **pic, const int *mas, SDL_Renderer *renderer)
{
    for(int i = 0; i < FIELD_CLM; ++i)
    {
        int x = CARD_X + i * CARD_W;
        int y = CARD_Y + 3 * CARD_H;
        switch(mas[i])
        {
        case 1:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[13], renderer);
            break;
        case 2:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[14], renderer);
            break;
        case 3:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[15], renderer);
            break;
        case 0:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[7], renderer);
            break;
        default:
            break;
        }
    }
}

void DrawGold(const SDL_Texture **pic, const int *mas, SDL_Renderer *renderer)
{
    for(int i = 0; i < FIELD_CLM; ++i)
    {
        int x = CARD_X + i * CARD_W;
        int y = CARD_Y + 2 * CARD_H;
        switch(mas[i])
        {
        case 1: case 2: case 3: case 4:
            ApplySurface(x, y, CARD_W, CARD_H, pic[20], renderer); // color
            break;
        case 5:
            ApplySurface(x, y, CARD_W, CARD_H, pic[29], renderer); // r2
            break;
        case 6: case 7:
            ApplySurface(x, y, CARD_W, CARD_H, pic[30], renderer); // r3
            break;
        case 8: case 9:
            ApplySurface(x, y, CARD_W, CARD_H, pic[31], renderer); // r4
            break;
        case 10:
            ApplySurface(x, y, CARD_W, CARD_H, pic[32], renderer); // r5
            break;
        case 11:
            ApplySurface(x, y, CARD_W, CARD_H, pic[33], renderer); // y2
            break;
        case 12: case 13:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[34], renderer); // y3
            break;
        case 14: case 15:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[35], renderer); // y4
            break;
        case 16:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[36], renderer); // y5
            break;
        case 17:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[25], renderer); // g2
            break;
        case 18: case 19:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[26], renderer); // g3
            break;
        case 20: case 21:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[27], renderer); // g4
            break;
        case 22:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[28], renderer); // g5
            break;
        case 23:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[21], renderer); // bl2
            break;
        case 24: case 25:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[22], renderer); // bl3
            break;
        case 26: case 27:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[23], renderer); // bl4
            break;
        case 28:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[24], renderer); // bl5
            break;
        case 29: case 30: case 31:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[16], renderer); // bonus1
            break;
        case 32:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[17], renderer); // bonus2
            break;
        case 33: case 34:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[10], renderer); // any
            break;
        case 35: case 36:
            ApplySurface(x, y, CARD_W, CARD_H, &pic[18], renderer); // random
            break;
        default:
            break;
        }
    }

}

void DrawPlace(const SDL_Texture **pic, SDL_Renderer *ren)
{
    int i = 0;
    int x = CARD_X + i++ * CARD_W;
    int y = CARD_Y + CARD_H;
    ApplySurface(x, y, CARD_W, CARD_H, &pic[8], ren); // A
    ApplySurface(x, y, CARD_W, CARD_H, &pic[9], ren); // B
    ApplySurface(x, y, CARD_W, CARD_H, &pic[10], ren); // C
    ApplySurface(x, y, CARD_W, CARD_H, &pic[11], ren); // D
    ApplySurface(x, y, CARD_W, CARD_H, &pic[12], ren); // E
}

void ApplyTextSurface(SDL_Surface *textSurface, SDL_Renderer *ren, SDL_Rect textLocation)
{
    SDL_Texture *tex = SDL_CreateTextureFromSurface(ren, textSurface);
    SDL_QueryTexture(tex, NULL, NULL, &textLocation.w, &textLocation.h);
    SDL_RenderCopy(ren, tex, NULL, &textLocation);
}

void Show_field(int **field, SDL_Texture **pic, SDL_Renderer *ren)
{
    ApplySurface(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT, pic[0], ren); // bg
    ApplySurface(SIDE_LEFT_X, SIDE_LEFT_Y, SIDE_W, SIDE_H, pic[6], ren); //score
    DrawInform(*pic, field[INFORM], ren);
    DrawPlace(*pic, ren);
    DrawGold(*pic, field[GOLD], ren);
    DrawBurg(*pic, field[BURG], ren);
    ApplySurface(SIDE_RIGHT_X, SIDE_RIGHT_Y, SIDE_W, SIDE_H, pic[1], ren); // cache
}
