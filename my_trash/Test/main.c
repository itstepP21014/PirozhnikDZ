#include <stdio.h>
#include <stdlib.h>
#include <SDL2/SDL.h>
#include <SDL/SDL_ttf.h>
#include <stdbool.h>

#define BLACK_COLOR 0,0,0
#define WHITE_COLOR 255,255,255
#define RED_COLOR 255,0,0
#define BLUE_COLOR 0,0,255

#define WINDOW_WIDTH 640
#define WINDOW_HEIGHT 480

int main ( int argc, char** argv )
{

    if(SDL_Init( SDL_INIT_EVERYTHING ) == -1) // инициализируем видео-подсистему
    {
        printf("SDL_Init failed: %s\n", SDL_GetError() ); return false;
    }

    if (TTF_Init() == -1)
    {
        printf("Unable to initialize SDL_ttf: %s \n", TTF_GetError());
    }

    SDL_Surface* screen = NULL;
    screen = SDL_CreateWindow("tex", 100, 100, WINDOW_WIDTH, WINDOW_HEIGHT, SDL_WINDOW_SHOWN);
    if(screen == NULL)
    {
        printf("Unable to load screen: %s \n", SDL_GetError()); return false;
    }

    TTF_Font* my_font = NULL;
    my_font = TTF_OpenFont("Old Comedy.ttf", 24); // или (ARIAL.TTF", 24)
    if(my_font == NULL)
    { // если он не загрузился и остался NULL
        printf("Unable to load font: %s \n", TTF_GetError()); return false;
    }

    SDL_Color fore_color = { RED_COLOR }; //255, 255 };
    SDL_Color back_color = { BLUE_COLOR };

    SDL_Surface* textSurface = NULL;
    textSurface = TTF_RenderText_Shaded(my_font, "To be or not to be.", fore_color, back_color);
    if(textSurface == NULL)
    {
        printf("Unable to load textsurface: %s \n", SDL_GetError()); return false;
    }

    // Pass zero for width and height to draw the whole surface
    SDL_Rect textLocation = { 100, 200, 0, 0 };

    SDL_BlitSurface(textSurface, NULL, screen, &textLocation); // скопируем тектовую сурфейс на экранную screen

    //SDL_Flip(screen); // отобразим сарфейс screen
    SDL_RenderPresent(textSurface);

    SDL_Delay(3000); // подождем

    SDL_FreeSurface(textSurface); // освободим поверхность для текста

    TTF_CloseFont(my_font); // закроем используемый шрифт

    TTF_Quit(); // закроем библиотеку шрифтов

    SDL_Quit(); // закроем SDL

    return 0;

}
