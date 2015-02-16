#define _XOPEN_SOURSE_EXTENDED
#define _POSIX_C_SOURSE 199309L

#include <sys/ioctl.h> //esli my zahotim izmenit' razmer konsoli (pishetsya vmeste s <signal.h>)
#include <signal.h>    //poluchaet signal ot OS o tom chto nuzhno pomenyat' razmer consoli
#include <stdio.h>
#include <stdlib.h>
#include <ncurses.h>
#include <locale.h>    //kodirovka?

enum Colors{normal, green, red}; // perechislenie cvetov
void treatSigWinch(int signo);

void initialiseProgram()
{
    setlocale(LC_ALL, "");
    initscr();   //zastavlyaem ncurses rabotat'
    signal (SIGWINCH, treatSigWinch); //vtoroy parametr nazyvaem kak hotim, perviy obyazatel'no tak
    if(has_colors()==FALSE)
    {
        endwin();
        fprintf(stderr, "no colors/n");
        exit(1);
    }
    cbreak();
    noecho(); //pryachem to chto nabiraem
    curs_set(0); //pryachem kursor
    start_color();
    //init_pair(1, COLOR_GREEN, COLOR_BLACK);
    init_pair(normal, COLOR_WHITE, COLOR_BLACK);
    init_pair(green, COLOR_GREEN, COLOR_BLACK);
    init_pair(red, COLOR_RED, COLOR_BLACK);

}

void treatSigWinch(int signo)
{
    struct winsize size;
    ioctl(1, TIOCGWINSZ, (char *) &size); //menyaem razmer konsoli
    resizeterm(size.ws_row, size.ws_col);
}


int main()
{
    initialiseProgram();

    attron(COLOR_PAIR(red)); //vklyuchaem cvet
    printw("Hello world!");
    attroff(COLOR_PAIR(red));
    refresh(); //ne zabyvat'!!!
    getch(); //ozhidaet lyubogo vvoda klavish
    attron(COLOR_PAIR(green));
    attron(A_BLINK|A_BOLD);
    move(0, 0);
    printw("Hello wor");
    attroff(A_BLINK|A_BOLD);
    attroff(COLOR_PAIR(green));
    refresh();
    getch();
    endwin();

    return 0;
}
