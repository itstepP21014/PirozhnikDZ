#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int lastNegativeSearch(int a[], int sizeArray)
{
    for(int i=sizeArray; i>=1; --i){
        if(a[i]<0) return i;
    }
    return -1;
}

int firstPositiveSearch(int a[], int sizeArray)
{
    for(int i=1; i<=sizeArray; ++i){
        if(a[i]>0) return i;
    }
    return -1;
}

void input_rand(int a[],int size)
{
    srand(time(NULL));
    for(int i=1; i<=size; ++i) a[i]=rand()%200-100;
}

void output(const int a[],int size)
{
    for(int i=1; i<=size; ++i) printf("a[%d]=%d\n", i, a[i]);
}
