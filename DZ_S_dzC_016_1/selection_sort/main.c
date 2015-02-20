#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define N 100

int check_sorting(const int mas[], int size);
void selection_sorting(int mas[], int sise);
void output(const int mas[], int size);
void generate(int mas[], int size);


int main()

{
    srand(time(NULL));
    int mas[N];
    int size = 10;
    generate(mas, size);
    output(mas,size);
    selection_sorting(mas,size);
    output(mas,size);
    return 0;
}

int check_sorting(const int mas[], int size)
{
    for(int i=0; i<size-1; ++i)
        if(mas[i]>mas[i+1]) return 0;
    return 1;
}

void selection_sorting(int mas[], int size)
{
    for(int i=size; i>0; --i)
    {
        int k;
        int max=mas[0];
        for(int j=1; j<i; ++j)
        {
            if(mas[j]>max)
            {
                max=mas[j];
                k=j;
            }
        }
    int x=mas[k];
    mas[k]=mas[i];
    mas[i]=x;
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
