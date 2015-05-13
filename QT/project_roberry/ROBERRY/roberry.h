#ifndef ROBERRY_H
#define ROBERRY_H

#include <SDL2/SDL.h>
#include <stdbool.h>

#define GOLD_CARD 36
#define ALL_PICTURES 37

#define SCREEN_WIDTH 1200
#define SCREEN_HEIGHT 700

#define BG_W
#define BG_H
#define CARD_X 220
#define CARD_Y 40
#define CARD_W 150
#define CARD_H 90
#define SIDE_W 180
#define SIDE_H 112
#define SIDE_LEFT_X 70
#define SIDE_LEFT_Y 130
#define SIDE_RIGHT_X 1010
#define SIDE_RIGHT_Y 130

// для массивов
#define FIELD_STR 4
#define FIELD_CLM 5
#define GOLD_STR 2
#define GOLD_CLM 4
#define A 0
#define B 1
#define C 2
#define D 3
#define E 4
#define INFORM 0
#define PLACE 1
#define JEWEL 2
#define BURG 3
#define BLUE 0
#define GREEN 1
#define RED 2
#define YELLOW 3
#define GOLD 0
#define CACHE 1

SDL_Window *win = NULL;
SDL_Renderer *ren = NULL;

void fill_place(int **field);
bool restore_field(int **field, int *gold);
void scoring_total(int **score);
int check_total(int **you, int **opponent, int total);
int check_winner(int you, int opponent);
void scoring_gold(const int n, int **score, int total);
void scoring_cache(int *score);

SDL_Texture* LoadImage(const char *file, SDL_Renderer ren);
void ApplySurface(int x, int y, int w, int h, SDL_Texture *tex, SDL_Renderer *rend);
void DrawPlace(const SDL_Texture *pic);
void ApplyTextSurface(SDL_Surface textSurface, SDL_Renderer ren, SDL_Rect textLocation);
void Show_field(int **field, SDL_Texture *pic, SDL_Renderer rer);

#endif // ROBERRY_H
