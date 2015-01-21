#include <stdio.h>
#include <stdlib.h>
#include "../../mylib/include/compatibility.h"

int main()
{
    int position=0, adding=1;
    while(1)
    {
        for(int i=0; i<position; ++i){
            printf(" ");
        }
        printf("#\n\n");
        universalSleep(0.04);
        universalClear();
        if(position<0 || position >=40){
            adding=-adding;
        }
        position+=adding;

    }
    return 0;
}
