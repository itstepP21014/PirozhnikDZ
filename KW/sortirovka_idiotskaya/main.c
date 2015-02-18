#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define N 100

int check_sorting(const int mas[], int size);
void idiot_sorting(int mas[], int sise);
void output(const int mas[], int size);
void generate(int mas[], int size);


int main()

{
    srand(time(NULL));
    int mas[N];
    int size = 10;
    generate(mas, size);
    output(mas,size);

    idiot_sorting(mas,size);

    output(mas,size);

    return 0;
}


int check_sorting(const int mas[], int size)
{
    for(int i=0; i<size-1; ++i)
        if(mas[i]>mas[i+1]) return 0;
    return 1;
}

void idiot_sorting(int mas[], int size)
{
    while(!check_sorting(mas, size))
    {
        int a=rand()%size;
        int b=rand()%size;
        int c=mas[a];
        mas[a]=mas[b];
        mas[b]=c;
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
