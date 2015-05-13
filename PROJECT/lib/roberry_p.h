#ifndef ROBERRY_H
#define ROBERRY_H

#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include <stdbool.h>

#define GOLD_CARD 36

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

// игровое поле
#define FIELD_STR 4
#define FIELD_CLM 5
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

// счет
#define GOLD_STR 2
#define GOLD_CLM 4
#define GOLD 0
#define CACHE 1

// массив картинок
#define EMPTY 0
#define SCORE_l 2
#define CACHE_R 3
#define CACHE_BLUE 4
#define CACHE_GREEN 5
#define CACHE_RED 6
#define CACHE_YELLOW 7
#define PLACE_A 8
#define PLACE_B 9
#define PLACE_C 10
#define PLACE_D 11
#define PLACE_E 12
#define GAMER1 13
#define GAMER2 14
#define GAMER_BOTH 15
#define BONUS1 16
#define BONUS2 17
#define RANDOM 18
#define ANY 19
#define COLOR 20
#define BLUE2 21
#define BLUE3 22
#define BLUE4 23
#define BLUE5 24
#define GREEN2 25
#define GREEN3 26
#define GREEN4 27
#define GREEN5 28
#define RED2 29
#define RED3 30
#define RED4 31
#define RED5 32
#define YELLOW2 33
#define YELLOW3 34
#define YELLOW4 35
#define YELLOW5 36

#define ALL_PICTURES 36

void fill_place(int **field);
bool restore_field(int **field, int *gold, int index);
void sum_score(int **score);
int check_total(const int **you, const int **opponent, int total);
int check_winner(const int you, const int opponent);
void scoring_gold(const int n, int **score, int total);
void scoring_cache(int *score);
void chose_informer(int **field, bool exit);
void chose_burgular(int **field, bool exit);
void chose_continue(bool exit, int new_game);
void chose_back(bool exit);
void choise_again(bool exit, int resume, int new_game);
void swap_array(int *array, const int size);
void get_prize(const int **field, int **your_score, int **opponent_score, int your_total, int opponent_total);

void DrawInformer(SDL_Renderer *ren, const int **field, const SDL_Texture* *pic, const SDL_Rect pos);
void DrawPlace(SDL_Renderer *ren, const SDL_Texture* *pic, const SDL_Rect pos);
void DrawJewel(SDL_Renderer *ren, const int **field, const SDL_Texture* *pic, const SDL_Rect pos);
void DrawBurgular(SDL_Renderer *ren, const int **field, const SDL_Texture* *pic, const SDL_Rect pos);
void ShowField(SDL_Renderer *ren, const int **field, const SDL_Texture* *pic, const SDL_Rect cardPos);
SDL_Texture* LoadImage(const char *file, SDL_Renderer *ren);
SDL_Texture* LoadText(const char *text, const TTF_Font *font, const SDL_Color color, SDL_Renderer *ren);
void ApplayChoise(const TTF_Font *font, const SDL_Color color, SDL_Renderer *ren);
void ApplayResults(const char *buf, const int buf_lenth, const TTF_Font *font, const SDL_Color color, SDL_Renderer *ren,
                 const int **your_score, const int **opponent_score, const int your_total, const int opponent_total);
void ApplayRound(const TTF_Font *font, const SDL_Color color, SDL_Renderer *ren,
                 const int **your_score, const int **opponent_score, const int your_total, const int opponent_total);
void ApplayRules(const TTF_Font *font, const SDL_Color font_color, SDL_Renderer *ren);

#endif // ROBERRY_H
