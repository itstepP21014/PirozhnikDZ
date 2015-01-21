#include <stdio.h>
#include <stdlib.h>

int fb(int n)
    {
        if(n>2){
            return fb(n-1)+fb(n-2);
        }
        else{
            return 1;
        }
    }

int main()
{
    printf("%d\n", fb(40));
    return 0;
}
