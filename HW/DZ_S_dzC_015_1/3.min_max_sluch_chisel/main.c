#include <stdio.h>
#include <stdlib.h>
#include "min_max_sluch_chisel.h"
#define N 1000

int main()
{
    int size, number, a[N];
    printf("Enter the size of array:\n");
    scanf("%d", &size);
    input_rand(a, size);
    output(a, size);
    minSearch(a, size);
    maxSearch(a, size);
    return 0;
}
