#define _XOPEN_SOURSE_EXTENDED
#define _POSIX_C_SOURSE 199309L

#include <sys/ioctl.h> //esli my zahotim izmenit' razmer konsoli (pishetsya vmeste s <signal.h>)
#include <signal.h>    //poluchaet signal ot OS o tom chto nuzhno pomenyat' razmer consoli
#include <stdio.h>
#include <stdlib.h>
#include <ncurses.h>
#include <locale.h>    //kodirovka?

#define ROWS 20
#define COLS 30

enum Colors{normal, green, red}; // perechislenie cvetov
enum State{opened, hidden, flagged};

char closedCell[4]="\342\226\243";
char flaggedCell[4]="\342\226\274";
char bombedCell[4] ="\342\227\216";

void treatSigWinch(int signo);
void initialiseProgram();

void initFields(int fogOfWar[][COLS], int field[][COLS], int rows, int cols);
void drawFields(int fogOfWar[][COLS], int field[][COLS], int rows, int cols, int curI, int curJ);
void runAround(int field[][COLS], int rows, int cols, int a, int b);
void inc(int field[][COLS], int rows, int cols, int i, int j);

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



void initFields(int fogOfWar[][COLS], int field[][COLS], int rows, int cols)
{
    for(int i=0; i<rows; ++i)
        for(int j=0; j<cols; ++j)
        {
            fogOfWar[i][j]=hidden;
            field[i][j]=0;
        }

    int cellsCount=rows*cols;
    int bombsCount=30;

    for(int i=0; i<bombsCount; ++i)
    {
        int bombPosition=rand()%cellsCount;
        int bombI=bombPosition/cols;
        int bombJ=bombPosition%cols;
        field[bombI][bombJ]=9;
        runAround(field, rows, cols, bombI, bombJ);
    }
}

void inc(int field[][COLS], int rows, int cols, int i, int j)
{
    if(i>=0 && i<rows && j>=0 && j<cols && field[i][j]<9) //poryadok obyazatel'no takoy
        ++field[i][j];
}

void runAround(int field[][COLS], int rows, int cols, int a, int b)
{
    for(int i=-1; i<2; ++i)
        for(int j=-1; j<2; ++j)
            inc(field, rows, cols, a+i, b+j);
}

void drawFields(int fogOfWar[][COLS], int field[][COLS], int rows, int cols, int curI, int curJ)
{
    for(int i=0; i<rows; ++i)
        for(int j=0; j<cols; ++j)
        {
            move(i, j);
            if(i==curI && j==curJ)
            {
                attron(A_REVERSE);
            }
            if(fogOfWar[i][j]==opened)
            {
                if(field[i][j]==0)
                    printw(" ");
                else if(field[i][j]<9)
                    printw("%d", field[i][j]);
                else if(field[i][j]==9)
                {
                    attron(A_BLINK|COLOR_PAIR(red));
                    printw("%s", bombedCell);
                    attroff(A_BLINK|COLOR_PAIR(red));
                }
            }
            else if(fogOfWar[i][j]==hidden)
                printw("%s", closedCell);
            else if(fogOfWar[i][j]==flagged)
                printw("%s", flaggedCell);
            else
            {
                endwin();
                fprintf(stderr, "internal error:\n"
                                "invalid value for fog\n");
                exit(1);
            }
            if(i==curI && j==curJ)
            {
                attroff(A_REVERSE);
            }
        }
}

int main()
{
    initialiseProgram();

    int fogOfWar[ROWS][COLS], field[ROWS][COLS];
    int curI=0, curJ=0;
    char key;
    initFields(fogOfWar, field, ROWS, COLS);

    do{
        drawFields(fogOfWar, field, ROWS, COLS, curI, curJ);
        //fogOfWar[0][0]=opened;
        //fogOfWar[3][2]=flagged;
        refresh();
        key=getch();
        switch(key)
        {
        case 'a':
            --curJ;
            curJ+=COLS;
            curJ%=COLS;
            break;
        case 'd':
            ++curJ;
            curJ+=COLS;
            curJ%=COLS;
            break;
        case 'w':
            --curI;
            curI+=ROWS;
            curI%=ROWS;
            break;
        case 's':
            ++curI;
            curI+=ROWS;
            curI%=ROWS;
            break;
        case ' ':
            fogOfWar[curI][curJ]=opened;
            break;
        }
    }while(key!='p');

    endwin();

    return 0;
}
