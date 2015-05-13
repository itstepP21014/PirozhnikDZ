#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <../lib/roberry_p.h>
#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include <SDL2/SDL_image.h>

void fill_place(int **field)
{
    for(int i = 0; i < FIELD_CLM; ++i)
        field[PLACE][i] = i; // возможно и + 1
}

bool restore_field(int **field, int *gold, int index)
{
    int i = 0;
    for(; (i < FIELD_STR) && (index <= GOLD_CARD); ++i)
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

void sum_score(int **score)
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

int check_winner(const int you, const int opponent)
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

void scoring_cache(int *score) // передаем score[CACHE]
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
                        done = false; // пользователь ошибся при вводе
                        break;
                    }
                }
            }
        }
    }
}

void chose_back(bool exit)
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
                    case SDLK_1:
                    {
                        exit = false;
                        break;
                    }
                    case SDLK_2:
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        done = false; // пользователь ошибся при вводе
                        break;
                    }
                }
                break;
            }
        }
    }
}

void choise_again(bool exit, int resume, int new_game)
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
                        done = false; // пользователь ошибся при вводе
                        break;
                    }
                }
            }
        }
    }
}

void swap_array(int *array, const int size)
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

void get_prize(int **field, int **your_score, int **opponent_score, int your_total, int opponent_total)
{
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
}

//SDL___________________________________________________________________________

void DrawInformer(SDL_Renderer *ren, int **field, SDL_Texture* *pic, const SDL_Rect pos)
{
    SDL_Rect tmp_pos = pos;
    for(int i = 0; i < FIELD_CLM; ++i)
    {
        switch (field[INFORM][i])
        {
        case 0:
            SDL_RenderCopy(ren, pic[EMPTY], NULL, &tmp_pos);
            break;
        case 1:
            SDL_RenderCopy(ren, pic[GAMER1], NULL, &tmp_pos);
            break;
        case 2:
            SDL_RenderCopy(ren, pic[GAMER2], NULL, &tmp_pos);
            break;
        case 3:
            SDL_RenderCopy(ren, pic[GAMER_BOTH], NULL, &tmp_pos);
            break;
        default:
            break;
        }
        tmp_pos.x += CARD_W;
    }
}

void DrawPlace(SDL_Renderer *ren, SDL_Texture* *pic, const SDL_Rect pos)
{
    SDL_Rect tmp_pos = pos;
    tmp_pos.y += CARD_H;

    SDL_RenderCopy(ren, pic[A], NULL, &tmp_pos);
    tmp_pos.x += CARD_W;
    SDL_RenderCopy(ren, pic[B], NULL, &tmp_pos);
    tmp_pos.x += CARD_W;
    SDL_RenderCopy(ren, pic[C], NULL, &tmp_pos);
    tmp_pos.x += CARD_W;
    SDL_RenderCopy(ren, pic[D], NULL, &tmp_pos);
    tmp_pos.x += CARD_W;
    SDL_RenderCopy(ren, pic[E], NULL, &tmp_pos);
}

void DrawJewel(SDL_Renderer *ren, int **field, SDL_Texture* *pic, const SDL_Rect pos)
{
    SDL_Rect tmp_pos = pos;
    tmp_pos.y += (2 * CARD_H);
    for(int i = 0; i < FIELD_CLM; ++i)
    {
        switch(field[JEWEL][i])
        {
        case 1: case 2: case 3: case 4:
            SDL_RenderCopy(ren, pic[COLOR], NULL, &tmp_pos);
            break;
        case 5:
            SDL_RenderCopy(ren, pic[RED2], NULL, &tmp_pos);
            break;
        case 6: case 7:
            SDL_RenderCopy(ren, pic[RED3], NULL, &tmp_pos);
            break;
        case 8: case 9:
            SDL_RenderCopy(ren, pic[RED4], NULL, &tmp_pos);
            break;
        case 10:
            SDL_RenderCopy(ren, pic[RED5], NULL, &tmp_pos);
            break;
        case 11:
            SDL_RenderCopy(ren, pic[YELLOW2], NULL, &tmp_pos);
            break;
        case 12: case 13:
            SDL_RenderCopy(ren, pic[YELLOW3], NULL, &tmp_pos);
            break;
        case 14: case 15:
            SDL_RenderCopy(ren, pic[YELLOW4], NULL, &tmp_pos);
            break;
        case 16:
            SDL_RenderCopy(ren, pic[YELLOW5], NULL, &tmp_pos);
            break;
        case 17:
            SDL_RenderCopy(ren, pic[GREEN2], NULL, &tmp_pos);
            break;
        case 18: case 19:
            SDL_RenderCopy(ren, pic[GREEN3], NULL, &tmp_pos);
            break;
        case 20: case 21:
            SDL_RenderCopy(ren, pic[GREEN4], NULL, &tmp_pos);
            break;
        case 22:
            SDL_RenderCopy(ren, pic[GREEN5], NULL, &tmp_pos);
            break;
        case 23:
            SDL_RenderCopy(ren, pic[BLUE2], NULL, &tmp_pos);
            break;
        case 24: case 25:
            SDL_RenderCopy(ren, pic[BLUE3], NULL, &tmp_pos);
            break;
        case 26: case 27:
            SDL_RenderCopy(ren, pic[BLUE4], NULL, &tmp_pos);
            break;
        case 28:
            SDL_RenderCopy(ren, pic[BLUE5], NULL, &tmp_pos);
            break;
        case 29: case 30: case 31:
            SDL_RenderCopy(ren, pic[BONUS1], NULL, &tmp_pos);
            break;
        case 32:
            SDL_RenderCopy(ren, pic[BONUS2], NULL, &tmp_pos);
            break;
        case 33: case 34:
            SDL_RenderCopy(ren, pic[ANY], NULL, &tmp_pos);
            break;
        case 35: case 36:
            SDL_RenderCopy(ren, pic[RANDOM], NULL, &tmp_pos);
            break;
        default:
            break;
        }
        tmp_pos.w += CARD_W;
    }

}

void DrawBurgular(SDL_Renderer *ren, int **field, SDL_Texture* *pic, const SDL_Rect pos)
{
    SDL_Rect tmp_pos = pos;
    tmp_pos.y += (3 * CARD_H);
    for(int i = 0; i < FIELD_CLM; ++i)
    {
        switch (field[BURG][i])
        {
        case 0:
            SDL_RenderCopy(ren, pic[EMPTY], NULL, &tmp_pos);
            break;
        case 1:
            SDL_RenderCopy(ren, pic[GAMER1], NULL, &tmp_pos);
            break;
        case 2:
            SDL_RenderCopy(ren, pic[GAMER2], NULL, &tmp_pos);
            break;
        case 3:
            SDL_RenderCopy(ren, pic[GAMER_BOTH], NULL, &tmp_pos);
            break;
        default:
            break;
        }
    tmp_pos.x += CARD_W;
    }
}

void ShowField(SDL_Renderer *ren, int **field, SDL_Texture* *pic, const SDL_Rect cardPos)
{
    // фон
    SDL_RenderCopy(ren, pic[EMPTY], NULL, NULL);
    // картинка слева
    SDL_Rect left = {70,130,112,180};
    SDL_RenderCopy(ren, pic[SCORE_l], NULL, &left);
    // картинка справа
    SDL_Rect right = {1010,130,112,180};
    SDL_RenderCopy(ren, pic[CACHE_R], NULL, &right);
    //информаторы
    DrawInformer(ren, field, pic, cardPos);
    // места кражи
    DrawPlace(ren, pic, cardPos);
    //сокровища
    DrawJewel(ren, field, pic, cardPos);
    //воры
    DrawInformer(ren, field, pic, cardPos);

}

SDL_Texture* LoadImage(const char *file, SDL_Renderer *ren)
{
    SDL_Surface *img = IMG_Load(file);
    if(img == NULL)
    {
        fprintf(stderr, "SDL_LoadBMP Error: %s\n", SDL_GetError());
    }
    SDL_Texture *tex = SDL_CreateTextureFromSurface(ren, img);
    SDL_FreeSurface(img);
    if(tex == NULL)
    {
        fprintf(stderr, "SDL_CreateTextureFromSurface Error: %s\n", SDL_GetError());
    }
    return tex;
}

SDL_Texture* LoadText(const char *text, TTF_Font *font, const SDL_Color color, SDL_Renderer *ren)
{
    SDL_Surface* textSurface = TTF_RenderText_Solid(font, text, color);
    if(textSurface == NULL)
    {
        printf("Unable to load textsurface: %s \n", SDL_GetError());
    }
    SDL_Texture *tex = SDL_CreateTextureFromSurface(ren, textSurface);
    SDL_FreeSurface(textSurface); // освободим поверхность для текста
    if(tex == NULL)
    {
        fprintf(stderr, "SDL_CreateTextureFromSurface Error(text): %s\n", SDL_GetError());
    }

    return tex;
}

void ApplayResults(const char *buf, const int buf_lenth, TTF_Font *font, const SDL_Color color, SDL_Renderer *ren,
                 int **your_score, int **opponent_score, const int your_total, const int opponent_total)
{
    SDL_Texture *buf0_tex = LoadText(buf, font, color, ren);
    SDL_Rect buf0_loc = { 20, 20, buf_lenth, 20 };
    SDL_RenderCopy(ren, buf0_tex, NULL, &buf0_loc);

    char buf1[256];
    char buf2[256];
    char buf3[256];
    char buf4[256];
    char buf5[256];
    char buf6[256];
    char buf7[256];

    sprintf(buf1, "                     У ВАС    У СОПЕРНИКА:");
    sprintf(buf2, "Синих:              %2d       %2d", your_score[GOLD][BLUE], opponent_score[GOLD][BLUE]);
    sprintf(buf3, "Зеленых:            %2d       %2d", your_score[GOLD][GREEN], opponent_score[GOLD][GREEN]);
    sprintf(buf4, "Красных:            %2d       %2d", your_score[GOLD][RED], opponent_score[GOLD][RED]);
    sprintf(buf5, "Желтых:             %2d       %2d", your_score[GOLD][YELLOW], opponent_score[GOLD][YELLOW]);
    sprintf(buf6, "-------------------------------");
    sprintf(buf7, "Итого с бонусами:   %2d       %2d", your_total, opponent_total);

    SDL_Texture *buf1_tex = LoadText(buf1, font, color, ren);
    SDL_Rect buf1_loc = { 20, 65, 420, 20 };
    SDL_RenderCopy(ren, buf1_tex, NULL, &buf1_loc);

    SDL_Texture *buf2_tex = LoadText(buf2, font, color, ren);
    SDL_Rect buf2_loc = { 20, 90, 330, 20 };
    SDL_RenderCopy(ren, buf2_tex, NULL, &buf2_loc);

    SDL_Texture *buf3_tex = LoadText(buf3, font, color, ren);
    SDL_Rect buf3_loc = { 20, 115, 330, 20 };
    SDL_RenderCopy(ren, buf3_tex, NULL, &buf3_loc);

    SDL_Texture *buf4_tex = LoadText(buf4, font, color, ren);
    SDL_Rect buf4_loc = { 20, 130, 330, 20 };
    SDL_RenderCopy(ren, buf4_tex, NULL, &buf4_loc);

    SDL_Texture *buf5_tex = LoadText(buf5, font, color, ren);
    SDL_Rect buf5_loc = { 20, 155, 330, 20 };
    SDL_RenderCopy(ren, buf5_tex, NULL, &buf5_loc);

    SDL_Texture *buf6_tex = LoadText(buf6, font, color, ren);
    SDL_Rect buf6_loc = { 20, 180, 330, 20 };
    SDL_RenderCopy(ren, buf6_tex, NULL, &buf6_loc);

    SDL_Texture *buf7_tex = LoadText(buf7, font, color, ren);
    SDL_Rect buf7_loc = { 20, 205, 330, 20 };
    SDL_RenderCopy(ren, buf7_tex, NULL, &buf7_loc);


    SDL_Texture *again = LoadText("Хотите сыграть еще раз?", font, color, ren);
    SDL_Rect again_loc = { 20, 270, 230, 20 };
    SDL_RenderCopy(ren, again, NULL, &again_loc);

    SDL_Texture *game = LoadText("1. Играть", font, color, ren);
    SDL_Rect game_loc = { 20, 295, 90, 20 };
    SDL_RenderCopy(ren, game, NULL, &game_loc);

    SDL_Texture *exit = LoadText("2. Выход", font, color, ren);
    SDL_Rect exit_loc = { 20, 320, 80, 20 };
    SDL_RenderCopy(ren, exit, NULL, &exit_loc);
}

void ApplayChoise(TTF_Font *font, const SDL_Color color, SDL_Renderer *ren)
{
    SDL_Texture* choise = LoadText("Что грабим и что охраняем?", font, color, ren);
    SDL_Rect choise_loc = { 220, 440, 260, 20 };
    SDL_RenderCopy(ren, choise, NULL, &choise_loc);

    SDL_Texture* a = LoadText("1. А", font, color, ren);
    SDL_Rect a_loc = { 220, 490, 40, 20 };
    SDL_RenderCopy(ren, a, NULL, &a_loc);

    SDL_Texture* b = LoadText("2. В", font, color, ren);
    SDL_Rect b_loc = { 220, 515, 40, 20 };
    SDL_RenderCopy(ren, b, NULL, &b_loc);

    SDL_Texture* c = LoadText("3. С", font, color, ren);
    SDL_Rect c_loc = { 220, 540, 40, 20 };
    SDL_RenderCopy(ren, c, NULL, &c_loc);

    SDL_Texture* d = LoadText("D", font, color, ren);
    SDL_Rect d_loc = { 220, 565, 40, 20 };
    SDL_RenderCopy(ren, d, NULL, &d_loc);

    SDL_Texture* e = LoadText("E", font, color, ren);
    SDL_Rect e_loc = { 220, 590, 40, 20 };
    SDL_RenderCopy(ren, e, NULL, &e_loc);
}

void ApplayRound(TTF_Font *font, const SDL_Color color, SDL_Renderer *ren,
                 int **your_score, int **opponent_score,
                 const int your_total, const int opponent_total)
{
    char buf1[256];
    char buf2[256];
    char buf3[256];
    char buf4[256];
    char buf5[256];
    char buf6[256];
    char buf7[256];
    char buf8[256];

    sprintf(buf1, "ВАШ СЧЕТ:               СЧЕТ СОПЕРНИКА:");
    sprintf(buf2, "Синих:    %2d(%2d)      Синих:     %2d", your_score[GOLD][BLUE], your_score[CACHE][BLUE], opponent_score[GOLD][BLUE]);
    sprintf(buf3, "Зеленых:  %2d(%2d)      Зеленых:   %2d", your_score[GOLD][GREEN], your_score[CACHE][GREEN], opponent_score[GOLD][GREEN]);
    sprintf(buf4, "Красных:  %2d(%2d)      Красных:   %2d", your_score[GOLD][RED], your_score[CACHE][RED], opponent_score[GOLD][RED]);
    sprintf(buf5, "Желтых:   %2d(%2d)      Желтых:    %2d", your_score[GOLD][YELLOW], your_score[CACHE][YELLOW], opponent_score[GOLD][YELLOW]);
    sprintf(buf6, "                        В тайнике (%2d)", opponent_score[CACHE][BLUE] + opponent_score[CACHE][GREEN] + opponent_score[CACHE][RED] + opponent_score[CACHE][YELLOW]);
    sprintf(buf7, "---------------         ------------");
    sprintf(buf8, "БОНУСЫ:   %2d           БОНУСЫ     %2d", your_total, opponent_total);

    SDL_Texture *buf1_tex = LoadText(buf1, font, color, ren);
    SDL_Rect buf1_loc = { 220, 400, 370, 20 };
    SDL_RenderCopy(ren, buf1_tex, NULL, &buf1_loc);

    SDL_Texture *buf2_tex = LoadText(buf2, font, color, ren);
    SDL_Rect buf2_loc = { 220, 425, 370, 20 };
    SDL_RenderCopy(ren, buf2_tex, NULL, &buf2_loc);

    SDL_Texture *buf3_tex = LoadText(buf3, font, color, ren);
    SDL_Rect buf3_loc = { 220, 450, 370, 20 };
    SDL_RenderCopy(ren, buf3_tex, NULL, &buf3_loc);

    SDL_Texture *buf4_tex = LoadText(buf4, font, color, ren);
    SDL_Rect buf4_loc = { 220, 475, 370, 20 };
    SDL_RenderCopy(ren, buf4_tex, NULL, &buf4_loc);

    SDL_Texture *buf5_tex = LoadText(buf5, font, color, ren);
    SDL_Rect buf5_loc = { 220, 500, 370, 20 };
    SDL_RenderCopy(ren, buf5_tex, NULL, &buf5_loc);

    SDL_Texture *buf6_tex = LoadText(buf6, font, color, ren);
    SDL_Rect buf6_loc = { 220, 525, 370, 20 };
    SDL_RenderCopy(ren, buf6_tex, NULL, &buf6_loc);

    SDL_Texture *buf7_tex = LoadText(buf7, font, color, ren);
    SDL_Rect buf7_loc = { 220, 550, 370, 20 };
    SDL_RenderCopy(ren, buf7_tex, NULL, &buf7_loc);

    SDL_Texture *buf8_tex = LoadText(buf8, font, color, ren);
    SDL_Rect buf8_loc = { 220, 575, 370, 20 };
    SDL_RenderCopy(ren, buf8_tex, NULL, &buf8_loc);


    SDL_Texture* back = LoadText("Продолжаем?", font, color, ren);
    SDL_Rect back_loc = { 220,610, 80, 20 };
    SDL_RenderCopy(ren, back, NULL, &back_loc);

    SDL_Texture* back1 = LoadText("1. Да", font, color, ren);
    SDL_Rect back1_loc = { 220, 635, 80, 20 };
    SDL_RenderCopy(ren, back1, NULL, &back1_loc);

    SDL_Texture* back2 = LoadText("2. Нет", font, color, ren);
    SDL_Rect back2_loc = { 220, 660, 80, 20 };
    SDL_RenderCopy(ren, back2, NULL, &back2_loc);
}

void ApplayRules(TTF_Font *font, const SDL_Color font_color, SDL_Renderer *ren)
{
    SDL_Texture* rulse = LoadText("ПРАВИЛА: ...", font, font_color, ren);
    SDL_Rect ruls_loc = { 20, 20, 120, 20 };
    SDL_RenderCopy(ren, rulse, NULL, &ruls_loc);

    SDL_Texture* back = LoadText("1. Назад", font, font_color, ren);
    SDL_Rect back_loc = { 20, 45, 80, 20 };
    SDL_RenderCopy(ren, back, NULL, &back_loc);

    SDL_Texture* exit = LoadText("2. Выход", font, font_color, ren);
    SDL_Rect exit_loc = { 20, 70, 80, 20 };
    SDL_RenderCopy(ren, exit, NULL, &exit_loc);
}
