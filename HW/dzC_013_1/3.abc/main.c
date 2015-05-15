#include <stdio.h>
#include <stdlib.h>

void printCompareSummAndNum(int a, int b, int c);

int main()
{
    int a, b, c;
    printf("Enter tree numbers:\n");
    scanf("%d%d%d", &a, &b, &c);
    printCompareSummAndNum(a, b, c);
    return 0;
}

void printCompareSummAndNum(int a, int b, int c)
{
    int summ;
    summ=a+b;
    if(summ>c){
        printf("%d + %d > %d\n", a, b, c);
    }
    else{
        if(summ<c){
            printf("%d + %d < %d\n", a, b, c);
        }
        else{
            printf("%d + %d = %d\n", a, b, c);
        }
    }
}
