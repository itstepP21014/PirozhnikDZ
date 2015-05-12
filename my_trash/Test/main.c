#include <stdio.h>
#include <stdlib.h>
#include <SDL2/SDL_ttf.h>
#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>
#include <stdbool.h>

int main()
{
    if(SDL_Init(SDL_INIT_VIDEO) != 0)
    {
        fprintf(stderr, "SDL_Init Error: %s\n", SDL_GetError());
        exit(1);
    }

    SDL_Window *win = SDL_CreateWindow("Hello World!", 100, 100, 800, 480, SDL_WINDOW_SHOWN);

    if(win == NULL)
    {
        fprintf(stderr, "SDL_CreateWindow Error: %s\n", SDL_GetError());
        exit(1);
    }

    SDL_Renderer *ren = SDL_CreateRenderer(win, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);

    if(ren == NULL)
    {
        SDL_DestroyWindow(win);
        fprintf(stderr, "SDL_CreateRender Error: %s\n", SDL_GetError());
        SDL_Quit();
        exit(1);
    }

// ______текст_______________________________________________
        TTF_Font* font = TTF_OpenFont("Old Comedy.ttf", 24);
        if(font == NULL)
        {
            printf("Unable to load font: %s \n", TTF_GetError());
            return false;
        }
        SDL_Color fore_color = {255, 0, 0, 255};
        //SDL_Color back_color = { BLUE_COLOR };

//___картинка_____________________________________________________________
    SDL_Surface *bmp = IMG_Load("../img/a.jpg");
    if(bmp == NULL)
    {
        SDL_DestroyRenderer(ren);
        SDL_DestroyWindow(win);
        fprintf(stderr, "SDL_LoadBMP Error: %s\n", SDL_GetError());
        SDL_Quit();
        exit(1);
    }
    SDL_Texture *tex = SDL_CreateTextureFromSurface(ren, bmp);
    SDL_FreeSurface(bmp);
    if(tex == NULL)
    {
        SDL_DestroyRenderer(ren);
        SDL_DestroyWindow(win);
        fprintf(stderr, "SDL_CreateTextureFromSurface Error: %s\n", SDL_GetError());
        SDL_Quit();
        exit(1);
    }
//____картинка__________________________________________________________________
    SDL_Surface *bmp2 = IMG_Load("../img/empty.jpg");
    if(bmp2 == NULL)
    {
        SDL_DestroyRenderer(ren);
        SDL_DestroyWindow(win);
        fprintf(stderr, "SDL_LoadBMP Error: %s\n", SDL_GetError());
        SDL_Quit();
        exit(1);
    }
    SDL_Texture *tex2 = SDL_CreateTextureFromSurface(ren, bmp2);
    SDL_FreeSurface(bmp);
    if(tex2 == NULL)
    {
        SDL_DestroyRenderer(ren);
        SDL_DestroyWindow(win);
        fprintf(stderr, "SDL_CreateTextureFromSurface Error: %s\n", SDL_GetError());
        SDL_Quit();
        exit(1);
    }
//***********************************************************************************
    SDL_RenderClear(ren);
//************************************************************************************

    //___для картинок_______________________________________________________________
    SDL_Rect Card = {0,0,150,90};

    SDL_Rect pos = {50,50,300,90};
    SDL_RenderCopy(ren, tex, &Card, &pos);

    SDL_Rect pos2 = {350,50,300,90};

    //_____для текста________________________________________________________


//************************************************************************************
    SDL_RenderCopy(ren, tex2, &Card, &pos2);
//************************************************************************************
    SDL_RenderPresent(ren);
    SDL_Delay(2000);

    SDL_DestroyTexture(tex);
    SDL_DestroyTexture(tex2);
    SDL_DestroyRenderer(ren);
    SDL_DestroyWindow(win);
    SDL_Quit();

    return 0;
}
