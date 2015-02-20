#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "../../mylib/include/arrays.h"
#include "../../mylib/include/sortings.h"

#define N 100

int main()

{
    srand(time(NULL));
    int mas[N];
    int size = 10;
    generate(mas, size);
    output(mas,size);
    buble_sorting(mas,size);
    output(mas,size);

    return 0;
}
