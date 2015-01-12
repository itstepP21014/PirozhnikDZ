#include <stdio.h>
#include <stdlib.h>

int main()
{
    int a, b, nod;
    printf("Vvedite dva chisla:\n");
    scanf("%d%d", &a, &b);
    if(b==0)
    {
        nod=a;
    }
    else
    {
        while(a%b!=0)
        {
            int c=a%b;
            a=b;
            b=c;
        }
        nod=b;
    }
    printf("Naimenshiy obshiy delitel Vashih chisel - %d.\n", nod);
    return 0;
}
