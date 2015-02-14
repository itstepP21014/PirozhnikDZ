#include <stdio.h>
#include <stdlib.h>
#include "massiv_ot_ruki.h"
#define N 1000

int main()
{
    int size, number, a[N];
    printf("Enter the size of array:\n");
    scanf("%d", &size);
    input(a, size);
    output(a,size);
    printf("Enter any number: ");
    scanf("%d", &number);
    numberSearch(a, number, size);
    if(numberSearch(a, number, size)>0){
        printf("Your number (%d) there is in the array. Its index is %d.\n", number, numberSearch(a, number, size));
    }
    else{
        printf("Your number (%d) there is no in the array.\n");
    }
    return 0;
}
