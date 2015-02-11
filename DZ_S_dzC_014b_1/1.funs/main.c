#include <stdio.h>
#include <stdlib.h>
#include "../../mylib/include/funs_with_digit.h"

int main()
{
    int N, M;
    printf("Enter one number:\n");
    scanf("%d", &N);
    printf("%d\n", digitCount(N));
    printf("%d\n", pickFirstFigure(N));
    printf("%d\n", amputateFirstFigure(N));
    printf("%d\n", shiftFirstFigure(N));
    printf("Enter one else number:\n");
    scanf("%d", &M);
    printf("%d\n", glueFigures(N, M));
    return 0;
}
