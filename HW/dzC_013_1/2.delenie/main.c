#include <stdio.h>
#include <stdlib.h>

void isDivision(int a, int b);

int main()
{
    int a, b;
    printf("Enter two numbers:\n");
    scanf("%d%d", &a, &b);
    isDivision(a, b);
    return 0;
}

void isDivision(int a, int b)
{
    if(a>b){
        if(a%b==0){
            printf("%d/%d", a, b);
        }
        else{
            printf("%d!/%d", a, b);
        }
    }
    else{
        if(b%a==0){
            printf("%d/%d", b, a);
        }
        else{
            printf("%d!/%d", b, a);
        }
    }
}
