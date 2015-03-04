#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int argc, char **argv)
{
    for(int i=0; i<argc; ++i)
        if(strcmp("--help", argv[i])==0)
        {
            printf("HELP");
            exit(0);
        }
    return 0;
}
