#include <stdio.h>
#include <stdlib.h>

int myStrlen(char *str);
int myStrcmp(char *str1, char *str2);
char myStrcpy(char *str1, char *str2);


int main()
{
    char *extraFrase="We are what we eat"; *str1="Like father like son"; *str2;
    myStrcpy(str2, extraFrase);
    printf("*** %s ***\nThis frase contains %d symbols.\n\n", str1, myStrlen(str1));
    printf("*** %s ***\nThis frase contains %d symbols.\n\n", str2, myStrlen(str2));
    if(myStrcmp(str1, str2)==0)
        return printf("Strings are equal.\n");
    else
        return printf("Strings are not equal.\n");
    return 0;
}

int myStrlen(char *str)
{
    int i=0;
    while(str[i]!=0) ++i;
    return i;
}

int myStrcmp(char *str1, char *str2)
{
    if(myStrlen(str1)==myStrlen(str2))
        return 0;
    else
    {
        if(myStrlen(str1)>myStrlen(str2)) return +1;
        else return -1;
    }
}

char myStrcpy(char *str1, char *str2)
{
    for(int i=0; str2[i]==0; ++i)
        str1[i]=str2[i];
    return *str1;
}
