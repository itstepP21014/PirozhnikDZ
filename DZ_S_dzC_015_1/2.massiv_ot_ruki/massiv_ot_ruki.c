#include <stdio.h>

void input(int a[],int size)
{
    for(int i=1; i<=size; ++i){
        printf("Enter the element of a[%d]: ", i);
        scanf("%d", &a[i]);
    }
}

void output(int a[],int size)
{
    for(int i=1; i<=size; ++i){
        printf("a[%d]=% d\n", i, a[i]);
    }
}

int numberSearch(int a[], int number, int size)
{
    for(int i=1; i<=size; ++i){
        if(a[i]==number){
            return i;
        }
    }
    return -1;
}
