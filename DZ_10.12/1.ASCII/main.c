#include <stdio.h>
#include <stdlib.h>

int main()
{
    for(int i=0; i<=127; ++i)
    {
        if(i%16==15)
        {
            printf("\n");
        }
        printf("%c ", i);
    }

    return 0;
}
