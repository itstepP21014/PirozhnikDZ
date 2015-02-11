#include <stdio.h>
#include <stdlib.h>
#include <time.h>


int main()
{
    int sdvig;
    printf("Vvedite kolichestvo sdvigov:\n");
    scanf("%d", &sdvig);

    printf("\nEto ishodnyj massiv:\n");
    int mas[2][6];
    int i=0, j=0;
    srand(time(NULL));
    for(i=0; i<2; ++i)
    {
        for(j=0; j<6; ++j)
        {
            mas[i][j]=rand()%9+1;
        }
    }
    for(i=0; i<2; ++i)
    {
        for(j=0; j<6; ++j)
        {
            printf("%d ", mas[i][j]);
        }
        printf("\n");
    }


    for(int k=1; k<=sdvig; ++k)
    {
        int a, b;
        a=mas[0][5];
        b=mas[1][5];
        for(i=0; i<2; ++i)
        {
            for(j=5; j>=0; --j)
            {
                mas[i][j]=mas[i][j-1];
                if(j==0 && i==0)
                    mas[i][j]=a;
                else
                {
                    if(j==0 && i==1)
                    mas[i][j]=b;
                }
            }
        }
    }

    printf("\nEto massiv s %d sdvigom(-ami):\n", sdvig);
    for(i=0; i<2; ++i)
    {
        for(j=0; j<6; ++j)
        {
            printf("%d ", mas[i][j]);
        }
        printf("\n");
    }
    return 0;

}
