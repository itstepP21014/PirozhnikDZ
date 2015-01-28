#include <stdio.h>
#include <stdlib.h>

void input(int a[],int size)
{
    for(int i=1; i<=size; ++i){
        printf("Enter the element of a[%d]: ", i);
        scanf("%d", &a[i]);
    }
}

void output(const int a[],int size)
{
    for(int i=1; i<=size; ++i){
        printf("a[%d]=%d\n", i, a[i]);
    }
}

void input_rand(int a[],int size)
{
    for(int i=1; i<=size; ++i){
        a[i]=rand()%(10+1);
    }
}
