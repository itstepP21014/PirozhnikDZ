#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i=2, chislo;
    printf("Vvedite chislo:\n");
    scanf("%d", &chislo);
    printf("%d=", chislo);
    do
    {
        if(chislo%i==0)
        {
            printf("%d*", i);
            chislo=chislo/i;
        }
        else
        {
            i++;
        }
    }while(i*i<=chislo);
    printf("%d", chislo);
    return 0;
}
