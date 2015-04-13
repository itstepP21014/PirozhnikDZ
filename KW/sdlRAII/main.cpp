#include <iostream>
#include <exception>
#include "sdlRAII.h"

using namespace std;

int main()
{
    try
    {
        SDLWrapper sdlWrapper;
        SDLWindowWrapper win("Hello RAII!", 100, 100, 640, 480, SDL_WINDOW_SHOWN);
        SDLRendererWrapper ren(win.win(), -1, SDL_RENDERER_ACCELERATED               // nullptr, chtoby vyzvat' avarijnuyu situaciyu
                               | SDL_RENDERER_PRESENTVSYNC);

        SDL_RenderClear(ren.ren());
        SDL_SetRenderDrawColor(ren.ren(), 0xFF, 0xFF, 0xFF, 0xFF);
        SDL_RenderDrawLine(ren.ren(), 0, 0, 640, 480);
        SDL_RenderPresent(ren.ren());
        SDL_Delay(5000);
        // win.~SDLWindowWrapper();    - vyzyvaem destructor vruchnuyu, etogo delat' ne stoit
    }
    catch(exception &e)
    {
        cerr << "ERROR: " << e.what() << endl;
    }
    catch(...)
    {
        cerr << "ERROR: something happend\n";
    }

    return 0;
}
