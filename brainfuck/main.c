#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define N 700

int main()
{
    char proga[]="++++++++++++++++++++++++.>+++++++++++++++++++++++++++++++++++++++++++++++++++++.>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.>!.>+++++++++++++++++++++++++++++++++++++++.>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.>++++++++++++++++++++++++++++++++++++++++++++++++++++.";
    char memory[N];
    for (int i=0; i<N; ++i){
        memory[i]='0';
    }
    int j=0;
    for(int i=0; i<strlen(proga); ++i){
        switch(proga[i]){
            case '+':
                memory[j]++;
                break;
            case '-':
                memory[j]--;
                break;
            case '>':
                ++j;
                break;
            case '<':
                --j;
                break;
            case '.':
                putchar(memory[j]);
                 break;
            case '!':
                memory[j]=' ';
                break;
        }
    }
    return 0;
}
