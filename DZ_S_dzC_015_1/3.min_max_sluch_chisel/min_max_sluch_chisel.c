#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void input_rand(int a[],int size)
{
    srand(time(NULL));
    for(int i=1; i<=size; ++i){
        a[i]=rand()%100+1;
    }
}

void output(int a[],int size)
{
    for(int i=1; i<=size; ++i){
        printf("a[%d]=% d\n", i, a[i]);
    }
}

int maxSearch(int a[], int size)
{
    int max=a[1];
    for(int i=1; i<=size; ++i){
        if(a[i]>=max){
            max=a[i];
        }
    }
    printf("MAX element in the array is %d.\n", max);
}

int minSearch(int a[], int size)
{
    int min=a[1];
    for(int i=1; i<=size; ++i){
        if(a[i]<=min){
            min=a[i];
        }
    }
    printf("MIN element in the array is %d.\n", min);
}
