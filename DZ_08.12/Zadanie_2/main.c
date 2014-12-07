#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Enter number >0: ");
    int n, i=1;
    scanf("%d", &n);
    while(i<=n)
    {
        printf("%d ", i);
        i=i+1;
    }
    return 0;
}
