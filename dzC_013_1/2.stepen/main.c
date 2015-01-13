#include <stdio.h>
#include <stdlib.h>

float pow(int number, int power);

int main()
{
    float number;
    int power;
    printf("Enter a double number and power (possible negative power):\n");
    scanf("%f%d", &number, &power);
    printf("%.1f in power %d = %f", number, power, pow(number, power));
    return 0;
}


 float pow(int number, int power)
 {
    float result=1.0;
    if(power>0){
        for(int i=1; i<=power; ++i){
            result*=number;
        }
        return result;
    }
    else{
        for(int i=-1; i>=power; --i){
            result*=number;
        }
        return 1/result;
    }
 }
