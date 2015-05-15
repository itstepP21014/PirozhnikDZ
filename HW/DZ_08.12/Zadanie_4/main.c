#include <stdio.h>
#include <stdlib.h>

int main()
{
    int result=1, n, x;
    printf("Enter the quantity of numbers: ");
    scanf("%d", &n);
    for(int i=1; i<=n; ++i)
    {
        printf("Enter a number: ", n);
        scanf("%d", &x);
        result*=x;
    }
    printf("Result=%d\n", result);
    return 0;
}
