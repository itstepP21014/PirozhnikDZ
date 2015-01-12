#include <stdio.h>
#include <stdlib.h>

int main()
{
    int number, summ=0;
    printf("Vvedite chislo:\n");
    scanf("%d", &number);
    while(number!=0)
    {
        summ+=number%10;
        number/=10;
    }
    printf("%d", summ);
    return 0;
}
