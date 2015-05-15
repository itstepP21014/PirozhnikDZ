#include <stdio.h>
#include <stdlib.h>
#include "../../mylib/include/myfuns.h"

int main()
{
    int a, b;
    printf("Enter two numbers:\n");
    scanf("%d%d", &a, &b);
    printf("GCD of %d and %d = %d.\n", a, b, gcd(a, b));
    printf("LCM of %d and %d = %d.\n", a, b, lcm(a, b));
    return 0;
}
