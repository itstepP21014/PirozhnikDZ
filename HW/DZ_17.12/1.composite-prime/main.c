#include <stdio.h>
#include <stdlib.h>

int main()
{
    int number, isComposite=0, i=2;
    printf("Enter your number >=2:\n");
    scanf("%d", &number);
   do
    {
        if(number==i)
        {
            isComposite=1;
            printf("Your number is PRIME.\n");
        }
        else
        {
            if(number%i==0)
            {
                printf("Your number is COMPOSITE.\n");
                isComposite=1;
            }
            else
            {
                i+=1;
            }
        }
    }while(isComposite==0);
    return 0;
}
