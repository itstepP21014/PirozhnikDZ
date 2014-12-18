#include <stdio.h>
#include <stdlib.h>

int main()
{
    long int resultat=1, n;
    printf("Vvedite chislo:\n");
    scanf("%d", &n);
    for(int i=1; i<=n; ++i)
    {
        resultat*=i;
    }
    printf("%ld! = %ld\n", n, resultat);
    return 0;
}
