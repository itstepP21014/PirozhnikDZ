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
    printf("Would you like enter arrya yourself or get it random?\n"
            "(yourself - press 1, random - press 2)\n");
    scanf("%d", &random_or_yourself);
    if(random_or_yourself==1){
        input(a, humanSize);
    }
    else{
        input_rand(a, humanSize);
    }
    // output(a,humanSize);
    int p=0;
    do{
        for(int i=humanSize-1; i>=0; --i){
            if(a[i]<0){
                printf("%d", a[i]);
                p=1;
            }
        }
    }while(p==0);
    return 0;
}
