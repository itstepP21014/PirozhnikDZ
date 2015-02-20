#include <stdlib.h>

void output(const int mas[], int size)
{
    for(int i=0; i<size; ++i)
    {
        printf("%4d ", mas[i]);
    }
    printf("\n");
}

void generate(int mas[], int size)
{
    for(int i=0; i<size; ++i)
    {
        mas[i]=rand()%1000;
    }
}
