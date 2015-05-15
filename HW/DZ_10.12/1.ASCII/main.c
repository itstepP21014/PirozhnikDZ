#include <stdio.h>
#include <stdlib.h>

int main()
{
    for(int i=0; i<=127; ++i)
    {
        printf("%4d", i);
        if(i%16==15)
        {
            printf("\n");
        }
    }

    return 0;
}
