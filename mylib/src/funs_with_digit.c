#include <stdio.h>

int digitCount(long long int N)
{
    int res, i=1;
    res=N;
    while(res>=10){
        res=res/10;
        ++i;
    }
    return i;
}

int pickFirstFigure(int N)
{
    int res;
    res=N;
    while(res>=10){
        res=res/10;
    }
    return res;
}

int amputateFirstFigure(int N)
{
    int res, p=1, answer;
    res=N;
    while(res>=10){
        res=res/10;
        ++p;
    }
    for(int i=1; i<=(p-1); ++i){
        res=res*10;
    }
    answer=N-res;
    return answer;
}

int shiftFirstFigure(int N)
{
    int res, p=1, answer, end;
    res=N;
    while(res>=10){
        res=res/10;
        ++p;
    }
    end=res;
    for(int i=1; i<=(p-1); ++i){
        res=res*10;
    }
    answer=N-res;
    return printf("%d%d\n", answer, end);
}

int glueFigures(int N, int M)
{
    return printf("%d%d", N, M);
}
