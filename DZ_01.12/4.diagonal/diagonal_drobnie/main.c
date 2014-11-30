#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Enter four numbers: ");
    double a, b, c, d;
    scanf("%lf%lf%lf%lf", &a, &b, &c, &d);
    printf("%.2f\n", a*2);
    printf(" %.2f\n", b*2);
    printf("  %.2f\n", c*2);
    printf("   %.2f\n", d*2);
    return 0;
}
