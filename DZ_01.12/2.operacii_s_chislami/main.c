#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Enter two numbers: ");
    int a, b;
    scanf("%d%d", &a, &b);
    printf("%d+%d=%d\n", a, b, a+b);
    printf("%d-%d=%d\n", a, b, a-b);
    printf("%d*%d=%d\n", a, b, a*b);
    printf("%d/%d=%d\n", a, b, a/b);
    printf("%d%%%d=%d\n", a, b, a%b);
    return 0;
}
