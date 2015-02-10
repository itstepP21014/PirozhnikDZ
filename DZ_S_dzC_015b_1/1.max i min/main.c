#include <stdio.h>
#include <stdlib.h>


int lastNegativeSearch(int a[], int sizeArray)
{
    for(int i=sizeArray; i>=1; --i){
        if(a[i]<0){
            return i;
        }
    }
    return -1;
}

int firstPositiveSearch(int a[], int sizeArray)
{
    for(int i=1; i<=sizeArray; ++i){
        if(a[i]>0){
            return i;
        }
    }
    return -1;
}


int main()
{
    printf("Hello world!\n");
    return 0;
}
