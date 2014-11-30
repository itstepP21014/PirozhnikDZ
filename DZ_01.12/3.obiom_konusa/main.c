#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Enter radius and height: ");
    double a, b;
    scanf("%lf%lf", &a, &b);
    printf("%.2f", (3.14*(a*a)*b)/3);
    return 0;
}
