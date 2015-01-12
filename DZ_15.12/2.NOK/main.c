#include <stdio.h>
#include <stdlib.h>

int main()
{
    int number_1, number_2, a, b, nod, nok, summ;
    printf("Vvedite dva chisla:\n");
    scanf("%d%d", &number_1, &number_2);
    a=number_1;
    b=number_2;
    if(b==0)
    {
        nod=a;
    }
    else
    {
        while(a%b!=0)
        {
            int c=a%b;
            a=b;
            b=c;
        }
        nod=b;
    }
    summ=number_1*number_2;
    nok=summ/nod;
    printf("Naimenshiy obshee kratnoe Vashih chisel - %d.\n", nok);
    return 0;
}
