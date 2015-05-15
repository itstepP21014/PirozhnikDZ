#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int i=0;
    char mas[i];
    printf("Vvedite skobki:\n");
    scanf("%s", &mas);
    int top=0;
    char mas_stack[strlen(mas)];
    for(i=0; i<=strlen(mas); ++i){
        if(mas[i]=='('||mas[i]=='['||mas[i]=='{'){
            mas_stack[top]=mas[i];
            ++top;
        }
        else{
            switch(mas[i]){
                case ']':
                    if(mas_stack[top-1]=='[') --top;
                    else return printf("Oshibka! Skobki rasstavlenny ne verno.\n");
                    break;
                case '}':
                    if(mas_stack[top-1]=='{') --top;
                    else return printf("Oshibka! Skobki rasstavlenny ne verno.\n");
                    break;
                 case ')':
                    if(mas_stack[top-1]=='(') --top;
                    else return printf("Oshibka! Skobki rasstavlenny ne verno.\n");
                    break;
            }
        }
    }
    if(top==0) return printf("Skobki rasstavlenny pravilno.\n");
    else return printf("Oshibka! Skobki rasstavlenny ne verno.\n");
    return 0;
}
