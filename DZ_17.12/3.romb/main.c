#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Vvedite diagonal romba:\n");
    int diagonal;
    scanf("%d", &diagonal);
    int center=(diagonal+1)/2;
    int n=center;
    int m=center;
    for(int p=1; p<=center; ++p){
        for(int i=1; i<=diagonal; ++i){
            if(i==n||i==m) printf("#");
            else printf(" ");
        }
        printf("\n");
        --n;
        ++m;
    }
    n=n+2;
    m=m-2;
    for(int p=center+1; p<=diagonal; ++p){
        for(int i=1; i<=diagonal; ++i){
            if(i==n||i==m) printf("#");
            else printf(" ");
        }
        printf("\n");
        ++n;
        --m;
    }

    return 0;
}
