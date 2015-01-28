#include <stdio.h>
#include <stdlib.h>
#include "../../mylib/include/random.h"

int main()
{
    int quant_N, max_N, N;
    printf("How much random numbers do you want?\n");
    scanf("%d", &quant_N);
    printf("Enter maximal value.\n");
    scanf("%d", &max_N);
    for(int i=1; i<=quant_N; ++i){
        N=random()%(max_N+1);
        if(N>=0){                 // to leave out negative numbers
            printf("%d\n", N);
        }
        else{
            i-=1;
        }
    }
    return 0;
}
