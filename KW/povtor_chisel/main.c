#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int mas[10][10];
    int i=0, j=0;
    srand(time(NULL));
    for(i=0; i<10; ++i)
    {
        for(j=0; j<10; ++j)
        {
            mas[i][j]=rand()%9+1;
        }
    }
    for(i=0; i<10; ++i)
    {
        for(j=0; j<10; ++j)
        {
            printf("%d ", mas[i][j]);
        }
        printf("\n");
    }

    printf("\n\n");

    int mas_max[9];
    for(int n=0; n<9; ++n)
    {
        mas_max[n]=0;
    }

    for(i=0; i<10; ++i)
    {
        for(j=0; j<10; ++j)
        {
            mas_max[mas[i][j]-1]+=1;
        }

    }
    for(int n=0; n<9; ++n)
    {
        printf("[%d] vstrechaetsya %d raz.\n", n+1, mas_max[n]);
    }
    return 0;
}

