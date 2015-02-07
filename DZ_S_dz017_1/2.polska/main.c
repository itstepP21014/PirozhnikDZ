#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int i=0, top=0;
    char polska[i];
    printf("Vvedite obratnuyu pol'skuyu zapis':\n");
    scanf("%s", &polska[i]);
    int stack[top];
    for(i=0; i<=strlen(polska); ++i){
        if(polska[i]=='*'||polska[i]=='+'||polska[i]=='-'||polska[i]=='/'||polska[i]=='='){
            stack[top]=polska[i];
            switch(polska[i]){
            case '*':
                stack[top-1]*=stack[top];
                --top;
                break;
            case '+':
                stack[top-1]+=stack[top];
                --top;
                break;
            case '-':
                stack[top-1]-=stack[top];
                --top;
                break;
            case '/':
                stack[top-1]/=stack[top];
                --top;
                break;
            case '=':
                return printf("%d\n", stack[top+1]);
                break;
            }
        }
        else{
            stack[top]=polska[i];
            ++top;
        }
    }
}

