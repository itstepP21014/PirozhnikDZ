#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    printf("Enter radius and height: ");
    double a, b, L;
    scanf("%lf%lf", &a, &b);
    printf("V=%.2f\n", (3.14*(a*a)*b)/3);
    L=sqrt(a*a+b*b);
    printf("S=%.2f\n", 3.14*a*(a+L));
    return 0;
}
