#include <stdio.h>
#include <stdlib.h>

int main()
{
    int chislo, stepen, resultat=1;
    printf("Vvedite chislo: ");
    scanf("%d", &chislo);
    printf("Vvedite stepen: ");
    scanf("%d", &stepen);
    if(stepen>0)
    {
        for(int i=1; i<=stepen; ++i)
    {
        resultat=resultat*chislo;
    }
    printf("Otvet: %d\n", resultat);
    }
    else
    {
        for(int i=-1; i>=stepen; i=i-1)
    {
        resultat=resultat*chislo;
    }
    printf("Otvet: 1/%d\n", resultat);
    }
    return 0;
}
