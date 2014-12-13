#include <stdio.h>
#include <stdlib.h>

int main()
{
    int result=1, p=0, x, L;
    printf("Enter the number >0: ");
    scanf("%d", &L);
    printf("Enter the number <=%d: ", L);
    scanf("%d", &x);
    while(result<=L)
    {
        result*=x;
        ++p;
    }
    printf("%d\n", p-1);
    return 0;
}
