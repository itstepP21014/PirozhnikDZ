#include <stdio.h>
#include <stdlib.h>

void printField(int n);
int gcd(int a, int b);


int main()
{
    int n;
    printf("Enter size of field:\n");
    scanf("%d", &n);
    printField(n);
    return 0;
}

void printField(int n)
{
    for(int j=1; j<=n; ++j){
        for(int i=1; i<=n; ++i){
            if(gcd(i, j)==1){
                printf("#");
            }
            else{
                printf(" ");
            }
        }
        printf("\n");
    }
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
