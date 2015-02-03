#include <stdio.h>
#include <stdlib.h>
#include "klasswork_28.01.h"
#define MAX_SIZE 1000

int main()
{
    int a[MAX_SIZE];
    int humanSize, random_or_yourself;
    printf("Enter the size of array:\n");
    scanf("%d", &humanSize);
    printf("Would you like enter array yourself or get it random?\n"
            "(yourself - press 1, random - press 2)\n");
    scanf("%d", &random_or_yourself);
    if(random_or_yourself==1){
        input(a, humanSize);
    }
    else{
        input_rand(a, humanSize);
    }
    output(a, humanSize);
    if(lastNegativeSearch(a, humanSize)>0){
        printf("The last negative element in the array - %d, its order number - %d.\n", a[lastNegativeSearch(a, humanSize)], lastNegativeSearch(a, humanSize));
    }
    else{
        printf("There is no any negative element in the array.\n");
    }
    if(firstPositiveSearch(a, humanSize)>0){
        printf("The first positive element in the array - %d, its order number - %d.\n", a[firstPositiveSearch(a, humanSize)], firstPositiveSearch(a, humanSize));
    }
    else{
        printf("There is no any positive element in the array.\n");
    }

    return 0;
}
