#include <stdio.h>
#include <stdlib.h>

int main()
{
    int w, h;
    printf("Enter two numbers: \n");
    scanf("%d%d", &w, &h);
    for(int i=1; i<=h; ++i)
    {
        for(int k=1; k<=w; ++k)
        {
            printf("* ");
        }
        printf("\n");
    }
    return 0;
}
