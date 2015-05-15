#include <stdio.h>
#include <stdlib.h>
#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>

void ApplySurface(int x, int y, int w, int h, SDL_Texture *tex, SDL_Renderer *ren);
SDL_Texture* LoadImage(const char *file, SDL_Renderer *ren);


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

    SDL_Renderer *ren = SDL_CreateRenderer(win, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);

    if(ren == NULL)
    {
        SDL_DestroyWindow(win);
        fprintf(stderr, "SDL_CreateRender Error: %s\n", SDL_GetError());
        SDL_Quit();
        exit(1);
    }



SDL_Texture *pic[2];

SDL_Texture *tex = LoadImage("../img/a.jpg", ren);
SDL_Texture *tex2 = LoadImage("../img/empty.jpg", ren);

/*
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
SDL_RenderCopy(ren, tex, NULL, NULL);

SDL_Surface *bmp2 = IMG_Load("../img/a.jpg");
if(bmp2 == NULL)
{
 SDL_DestroyRenderer(ren);
 SDL_DestroyWindow(win);
 fprintf(stderr, "SDL_LoadBMP Error: %s\n", SDL_GetError());
 SDL_Quit();
 exit(1);
}
SDL_Texture *tex2 = SDL_CreateTextureFromSurface(ren, bmp2);
SDL_FreeSurface(bmp2);
if(tex == NULL)
{
 SDL_DestroyRenderer(ren);
 SDL_DestroyWindow(win);
 fprintf(stderr, "SDL_CreateTextureFromSurface Error: %s\n", SDL_GetError());
 SDL_Quit();
 exit(1);
}
SDL_RenderCopy(ren, tex2, NULL, NULL);
*/
pic[0] = tex;
pic[1] = tex2;

    SDL_RenderClear(ren);
    ApplySurface(0, 0, 200, 200, pic[1], ren);
     ApplySurface(50, 50, 200, 200, pic[0], ren);

    SDL_RenderPresent(ren);
    //Have the program wait for 2000ms so we get a chance to see the
    SDL_Delay(4000);

    SDL_DestroyTexture(tex);
     SDL_DestroyTexture(tex2);
    SDL_DestroyRenderer(ren);
    SDL_DestroyWindow(win);
    SDL_Quit();

    return 0;
}

void ApplySurface(int x, int y, int w, int h, SDL_Texture *tex, SDL_Renderer *ren)
{
   SDL_Rect pos;
   pos.x = x;
   pos.y = y;
   SDL_QueryTexture(tex, NULL, NULL, &w, &h);
   SDL_RenderCopy(ren, tex, NULL, &pos);
}

SDL_Texture* LoadImage(const char *file, SDL_Renderer *ren)
{
    SDL_Surface *bmp = IMG_Load(file);
    if(bmp == NULL)
    {
    ;
        fprintf(stderr, "SDL_LoadBMP Error: %s\n", SDL_GetError());
        exit(1);
    }
    SDL_Texture *tex = SDL_CreateTextureFromSurface(ren, bmp);
    SDL_FreeSurface(bmp);
    if(tex == NULL)
    {

        fprintf(stderr, "SDL_CreateTextureFromSurface Error: %s\n", SDL_GetError());
        exit(1);
    }
    SDL_RenderCopy(ren, tex, NULL, NULL);
    return tex;
}