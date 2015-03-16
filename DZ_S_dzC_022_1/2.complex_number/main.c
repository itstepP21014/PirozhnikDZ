#include <stdio.h>
#include <stdlib.h>

typedef struct Complex_ {
    int real;
    int imag;
} Complex;



#define MAX 2

int main()
{
    Complex complexNum[MAX];
    char imaginary = 'i';
    for(int i=0, index=0; index < MAX; ++i, ++index)
    {
        printf("Enter two elements of [%d] complex number:\n", index + 1);
        scanf("%d %d", &complexNum[i].real, &complexNum[i].imag);
        if(complexNum[i].real >= 0 && complexNum[i].imag >= 0)
            printf("[%d] %d + %d%c\n", index + 1, complexNum[i].real, complexNum[i].imag, imaginary);
        else
        {
            if(complexNum[i].real < 0 && complexNum[i].imag >= 0)
                printf("[%d] %d%c - %d\n", index + 1, complexNum[i].imag, imaginary, complexNum[i].real * (-1));
            else
                printf("[%d] %d - %d%c\n", index + 1, complexNum[i].real, complexNum[i].imag * (-1), imaginary);
        }
    }

    return 0;
}
