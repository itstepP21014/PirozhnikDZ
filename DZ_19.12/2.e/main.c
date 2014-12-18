#include <stdio.h>
#include <stdlib.h>

int main()
{
    float chiresultat=0.0, adding=1.0, eps=1e-6, n=1.0, resultat=1;
    for(float chislo=-2.0; chislo<=2.0; chislo=chislo+0.1)
    {
        while(fabs (adding)>=eps)
            {
                resultat*=adding;
                adding*=chislo/n;
                ++n;
            }
            printf("Chislo: % .1f, my exp = %f, exp = %f, raznica = %f\n", chislo, resultat, exp(chislo), resultat-exp(chislo));
    }
    return 0;
}
