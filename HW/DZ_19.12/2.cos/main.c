#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    float adding, eps=1e-6, resultat;
    int n;
    for(float chislo=-2.0; chislo<2.1; chislo=chislo+0.1){
        resultat=0.0;
        n=1.0;
        adding=1.0;
        while(fabs (adding)>=eps){
            resultat+=adding;
            adding*=(-1)*chislo*chislo/(2*n-1)/(2*n);
            ++n;
        }
        printf("Chislo: % .1f, my cos = % f, cos = % f, raznica = % f\n", chislo, resultat, cos(chislo), resultat-cos(chislo));
    }
    return 0;
}
