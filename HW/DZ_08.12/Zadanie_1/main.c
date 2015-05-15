#include <stdio.h>
#include <stdlib.h>

int main()
{
    char text[]="Hello World!";
    for(int i=1; i<=137; i=i+1)
    {
        printf("%s\n", text);
    }
    return 0;
}
