#include <stdio.h>
#include <stdlib.h>

int gcd(int a, int b);
int lcm(int a, int b);

int main()
{
    int a, b, gcd;
    printf("Enter two numbers:\n");
    scanf("%d%d", &a, &b);
    printf("GCD of %d and %d = %d.\n", a, b, gcd(a, b));  // пишет что gcd не функция
    printf("LCM of %d and %d = %d.\n", a, b, lcm(a, b));
    return 0;
}

int gcd(int a, int b)
{
    if(b==0){return a;}
    else{
        while(a%b!=0){
            int c=a%b;
            a=b;
            b=c;
        }
        return b;
    }
}


int lcm(int a, int b)
{
    int summ=a*b;
    return summ/(gcd(a, b));
}

