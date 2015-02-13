#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    printf("Vvedite razmer massiva:\n");
    int sizeArray;
    scanf("%d", &sizeArray);
    int mas[sizeArray];
    srand(time(NULL));
    for(int i=0; i<=sizeArray; ++i)
        mas[i]=rand()%20-10;
    for(int i=0; i<sizeArray; ++i)
        printf("[%d]=% d\n", i, mas[i]);
    for(int i=0; i<=sizeArray; ++i){
        if(mas[i]%2==0)
    return 0;
}
