#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int i=0, top=0;
    char polska[i];
    printf("Vvedite obratnuyu pol'skuyu zapis':\n");
    scanf("%s", &polska[i]);
    char polska_stack[top];
    polska_stack[top]=polska[i];
    for(i=0; i<=strlen(polska); ++i){
            switch(polska_stack[top]){
            case '*':
                polska_stack[top-2]*=polska_stack[top-1];
                top-=3;
                break;
            case '+':
                polska_stack[top-2]+=polska_stack[top-1];
                top-=3;
                break;
            case '-':
                polska_stack[top-2]-=polska_stack[top-1];
                top-=3;
                break;
            case '/':
                polska_stack[top-2]/=polska_stack[top-1];
                top-=3;
                break;
            case '=':
                return printf("%d\n", polska_stack[top]);
                break;
            }
            ++top;
    }
    return 0;
}
