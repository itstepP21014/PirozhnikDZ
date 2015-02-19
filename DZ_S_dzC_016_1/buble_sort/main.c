#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define N 100

int check_sorting(const int mas[], int size);
void buble_sorting(int mas[], int sise);
void output(const int mas[], int size);
void generate(int mas[], int size);


int main()

{
    srand(time(NULL));
    int mas[N];
    int size = 10;
    generate(mas, size);
    output(mas,size);

    buble_sorting(mas,size);

    output(mas,size);

    return 0;
}


int check_sorting(const int mas[], int size)
{
    for(int i=0; i<size-1; ++i)
        if(mas[i]>mas[i+1]) return 0;
    return 1;
}

void buble_sorting(int mas[], int size)
{
    while(!check_sorting(mas, size))
    {
        for(int i=0; i<size; ++i)
        {
            if(mas[i]>mas[i+1])
            {
                int x=mas[i];
                mas[i]=mas[i+1];
                mas[i+1]=x;
            }
        }
    }
}

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
