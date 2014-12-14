#include <stdio.h>
#include <stdlib.h>

int main()
{
    int w, h;
    printf("Enter two numbers: \n");
    scanf("%d%d", &w, &h);
    for(int k=1; k<=h; ++k)
    {
        if(k==1||k==h)
        {
            for(int i=1; i<=w; ++i)
            {
                printf("# ");
            }
        }
        else
        {
            for(int i=1; i<=w; ++i)
            {
                if(i==1||i==w)
                {
                    printf("# ");
                }
                else
                {
                    printf("  ");
                }
            }
        }
        printf("\n");
    }
    return 0;
}
