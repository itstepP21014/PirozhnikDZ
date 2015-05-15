#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Enter number and its power >=0: ");
    int x, p, answer;
    scanf("%d%d", &x, &p);
    answer=x;
    for(int i=1; i<p; i=i+1)
    {
        x=answer*x;
    }
    printf("%d\n", x);
     return 0;
}
