#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <unistd.h>

#define 512 32
int main()
{
    signed char buf[512];
    int chastota = 44100 * 5 / 512;
    for(int i = 0; i < chastota; ++i)
    {
        for(int j = 0; j < 512; ++j)
        {
            buf[j] = 120 * sin( (i * 128 + j) * 2 * 3.1415926536 * 440.0 / 44100.0);
        }
        write(1, buf, 512 * sizeof(signed char));
    }
    return 0;
}
