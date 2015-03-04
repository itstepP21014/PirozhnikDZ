#include <stdlib.h>
#include <stdio.h>

void outputArray(const int *mas, int size)
{
    for(int i=0; i<size; ++i)
    {
        printf("%4d ", mas[i]);
    }
    printf("\n");
}

void generateArray(int *mas, int size)
{
    for(int i=0; i<size; ++i)
    {
        mas[i]=rand()%1000;
    }
}
