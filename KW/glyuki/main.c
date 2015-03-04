#include <stdio.h>
#include <stdlib.h>

/*
// bag №1

int main()
{
    long long int a=0xFEFEFEFEFEFEFEFE;
    char str[9]="mamarama";             // "mama\n123"
    long long int b=0xDADADADADADADADA;
    printf("%s\n", str);
    for(char *p=str; *p; ++p)
        printf("%c\t%#x\n", *p, *p);
    return 0;
}
*/

// bag №2

int main()
{
    char str1[5]="mama";
    char *str2="mama";
    printf("%s\n%s\n", str1, str2);
    str1[0]='r';                     // str2[0]='r'; - programm will be killed
    printf("%s\n%s\n", str1, str2);
    return 0;
}
