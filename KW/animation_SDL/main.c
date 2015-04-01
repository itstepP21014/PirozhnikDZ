#include <stdio.h>
#include <stdlib.h>
#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>
#include <math.h>
#include <stdbool.h>

int main()
{
    if(SDL_Init(SDL_INIT_VIDEO) != 0)
    {
        fprintf(stderr, "SDL_Init Error: %s\n", SDL_GetError());
        exit(1);
    }

    SDL_Window *win = SDL_CreateWindow("Hello World!", 100, 100, 640, 480, SDL_WINDOW_SHOWN);

    if(win == NULL)
    {
        fprintf(stderr, "SDL_CreateWindow Error: %s\n", SDL_GetError());
        exit(1);
    }

    if(!IMG_Init(IMG_INIT_PNG))
    {
        fprintf(stderr, "SDL_ImageInit Error: %s\n", IMG_GetError());
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

    SDL_Surface *bmp = IMG_Load("wave.png");

    if(bmp == NULL)
    {
        SDL_DestroyRenderer(ren);
        IMG_Init(IMG_INIT_PNG);
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

    SDL_SetRenderDrawColor(ren, 0x00, 0xFF, 0x00, 0xFF);
    SDL_RenderClear(ren);

    int x=0, y=0, t=0;
    // drawing round
    /*
    while(1)
    {
        for(int i=0; i<12; ++i)
        {
            x= 192*cos((3.14*i/6)+t);
            y= 192*sin((3.14*i/6)+t);
            SDL_Rect dst={x+288, y+208, 64, 64};
            SDL_RenderCopy(ren, tex, NULL, &dst);
        }

        ++t;

        SDL_RenderPresent(ren);
        SDL_RenderClear(ren);
        SDL_Delay(100);
    }
    */

    // drawing animation
    bool quit = false;
    SDL_Event e;
    while(!quit)
    {
        int ticks = SDL_GetTicks();
        int sprite = (ticks/150)%4;
        while(SDL_PollEvent(&e))
        switch(e.type)
        {
        case SDL_QUIT:
            quit = true;
            break;
        }

        SDL_Rect dst={x+288, y+208, 128, 128};
        SDL_Rect src= {sprite*128, 0, 128, 128};
        SDL_RenderCopy(ren, tex, &src, &dst);
        SDL_RenderPresent(ren);
        SDL_RenderClear(ren);
        t=(t+1)%4;
    }

    SDL_RenderPresent(ren);
    //Have the program wait for 2000ms so we get a chance to see the
    SDL_Delay(1000000000);

    SDL_DestroyTexture(tex);
    SDL_DestroyRenderer(ren);
    IMG_Quit();
    SDL_DestroyWindow(win);
    SDL_Quit();

    return 0;
}
