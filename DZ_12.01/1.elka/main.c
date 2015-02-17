#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Vvedite kolichestvo yarusov elki:\n");
    int yarus;
    scanf("%d", &yarus);

    int diagonal=1;
    for(int raz=1; raz<=yarus; ++raz){
        diagonal+=2;
        int center=(diagonal+1)/2;
        int n=center;
        int m=center;
        for(int p=1; p<center; ++p){
            for(int i=1; i<=diagonal; ++i){
                if(i==n||i==m) printf("*");
                else printf(" ");
            }
            printf("\n");
            --n;
            ++m;
        }
        for(int i=1; i<=diagonal; ++i)
            printf("*");
        printf("\n");
    }
    return 0;
}
