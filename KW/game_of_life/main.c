#include <stdio.h>
#include <stdlib.h>
#include <SDL2/SDL.h>
#include <SDL2/SDL2_gfxPrimitives.h>
#include <stdbool.h>
#include <math.h>

#define SCREEN_WIDTH 640
#define SCREEN_HEIGHT 480


int main()
{
    if(SDL_Init(SDL_INIT_VIDEO) != 0)
    {
        fprintf(stderr, "SDL_Init Error: %s\n", SDL_GetError());
        exit(1);
    }

    SDL_Window *win = SDL_CreateWindow("Hello World!", 100, 100, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN);

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

    SDL_RenderClear(ren);

    bool quit = false;

    SDL_Event e;

    int x = 10, y = 10;

    int virus[48][64];

    for(int i = 0; i < 48; ++i)
    {
        for(int j = 0; j < 64; ++j)
            virus[i][j] = 0;
    }

    while(!quit)
    {
        while(SDL_PollEvent(&e) != 0)
        {
            if(e.type == SDL_QUIT)
                quit = true;
            if(e.type == SDL_KEYDOWN)
            {
                SDL_KeyboardEvent kEvent = e.key;
                if(kEvent.keysym.scancode == SDL_SCANCODE_A)
                {
                    x = (x - 10 + SCREEN_WIDTH) % SCREEN_WIDTH;
                }
                if(kEvent.keysym.scancode == SDL_SCANCODE_D)
                {
                    x = (x + 10 + SCREEN_WIDTH) % SCREEN_WIDTH;
                }
                if(kEvent.keysym.scancode == SDL_SCANCODE_W)
                {
                    y = (y - 10 + SCREEN_HEIGHT) % SCREEN_HEIGHT;
                }
                if(kEvent.keysym.scancode == SDL_SCANCODE_S)
                {
                    y = (y + 10 + SCREEN_HEIGHT) % SCREEN_HEIGHT;
                }
                if(kEvent.keysym.scancode == SDL_SCANCODE_G)
                {
                    virus[y/10][x/10] = 1;
                }
            }
            SDL_RenderPresent(ren);
            if(e.type == SDL_MOUSEBUTTONDOWN)
                quit = true;
        }

        SDL_Rect squr;
        squr.x = x;
        squr.y = y;
        squr.w = 10;
        squr.h = 10;

        SDL_SetRenderDrawColor(ren, 0x00, 0x00, 0x00, 0xFF);
        SDL_RenderClear(ren);

        SDL_SetRenderDrawColor(ren, 0xFF, 0x00, 0xFF, 0xFF);
        SDL_RenderFillRect(ren, &squr);

        for(int i = 0; i < 48; ++i)
        {
            for(int j = 0; j < 64; ++j)
            {
                if(virus[i][j] == 1)
                {
                    squr.x = j*10;
                    squr.y = i*10;
                    SDL_SetRenderDrawColor(ren, 0xFF, 0xFF, 0xFF, 0xFF);
                    SDL_RenderFillRect(ren, &squr);
                }
            }
        }
        SDL_RenderPresent(ren);
    }

    SDL_DestroyRenderer(ren);
    SDL_DestroyWindow(win);
    SDL_Quit();

    return 0;
}
