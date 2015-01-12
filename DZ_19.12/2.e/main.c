#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    float resultat, adding, eps=1e-6;
    int n;
    for(float chislo=-2.0; chislo<=2.0; chislo=chislo+0.1){
        adding=1.0;
        n=1;
        resultat=0.0;
        while(fabs (adding)>=eps){
            resultat+=adding;
            adding*=chislo/n;
            ++n;
        }
        printf("Chislo: % .1f, my exp = %f, exp = %f, raznica = % f\n", chislo, resultat, exp(chislo), resultat-exp(chislo));
    }
    return 0;
}
