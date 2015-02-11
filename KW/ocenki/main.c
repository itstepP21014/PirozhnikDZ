#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int mas[5][5];
    int i=0, j=0;
    srand(time(NULL));
    for(i=0; i<5; ++i)
    {
        for(j=0; j<5; ++j)
        {
            mas[i][j]=rand()%12+1;
        }
    }
    for(i=0; i<5; ++i)
    {
        for(j=0; j<5; ++j)
        {
            printf("%d\t", mas[i][j]);
        }
        printf("\n");
    }

for(i=0; i<5; ++i)
{
    for(j=0; j<5; ++j)
    {
    switch(mas[i][j]){
        case 1:
        case 2:
        case 3:
        mas[i][j]=2;
        break;
        case 4:
        case 5:
        case 6:
        mas[i][j]=3;
        break;
        case 7:
        case 8:
        case 9:
        mas[i][j]=4;
        break;
        case 10:
        case 11:
        case 12:
        mas[i][j]=5;
        break;
    }
    }
}
printf("\n\n");
for(i=0; i<5; ++i)
    {
        for(j=0; j<5; ++j)
        {
            printf("%-d  ", mas[i][j]);
        }
        printf("\n");
    }

    return 0;
}
