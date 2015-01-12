#include <stdio.h>
#include <stdlib.h>

int main()
{
    float adding=1.0, eps=1e-6, n=1.0, resultat=0;
    for(float chislo=-2.0; chislo<2.1; chislo=chislo+0.1)
    {
        adding=chislo;
        while(fabs (adding)>=eps)
            {
                resultat+=adding;
                adding*=(-1)*chislo*chislo/(2*n+1)/(2*n);
                ++n;
            }
            printf("Chislo: % .1f, my sin = % f, sin = % f, raznica = % f\n", chislo, resultat, sin(chislo), resultat-sin(chislo));
    }
    return 0;
}
