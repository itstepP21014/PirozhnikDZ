#include <stdio.h>
#include <stdlib.h>

int main()
{
   int a=1, b=0, resultat;
    for(int i=1; i<=40; ++i)
    {
        resultat=a+b;
        printf("%9*d %9*f %9*f\n", resultat, 1.0*resultat/b, 1.0*b/resultat);
        a=b;
        b=resultat;
    }
    return 0;
}
