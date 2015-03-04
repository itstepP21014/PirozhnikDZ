#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "../../mylib/include/arrays.h"
#include "../../mylib/include/sortings.h"

#define N 100

int main()

{
    srand(time(NULL));
    int *mas=NULL;
    int size = 10;
    mas=(int*)malloc(size*sizeof(int));
    generateArray(mas, size);
    outputArray(mas,size);
    buble_sorting(mas,size);
    outputArray(mas,size);

    free(mas);
    mas=NULL;
    return 0;
}
