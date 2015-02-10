#include <stdio.h>
#include <stdlib.h>
#include "max i min.h"

int main()
{
    int humanSize;
    printf("Enter the size of array:\n");
    scanf("%d", &humanSize);
    int arr[humanSize];
    input_rand(arr, humanSize);
    output(arr, humanSize);
    lastNegativeSearch(arr, humanSize);
    firstPositiveSearch(arr, humanSize);
    if(lastNegativeSearch(arr, humanSize)>0){
        if(firstPositiveSearch(arr, humanSize)>0){
            int zuzu=arr[lastNegativeSearch(arr, humanSize)];
            arr[lastNegativeSearch(arr, humanSize)]=arr[firstPositiveSearch(arr, humanSize)];
            arr[firstPositiveSearch(arr, humanSize)]=zuzu;
            printf("\n\n");
            output(arr, humanSize);
        }else printf("There is no any positive element in the array.\n");
    }else printf("There is no any negative element in the array.\n");
    return 0;
}

