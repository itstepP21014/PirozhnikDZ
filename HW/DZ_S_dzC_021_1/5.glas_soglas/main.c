#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

#define MAX_SIZE 10000

void showFile(FILE *file);

int main()
{
    FILE *file;
    file = fopen("text.txt", "r");
    if(file == NULL)
    {
        printf("Error! The file could not be found.\n");
        exit(-1);
    }
    showFile(file);

    // count vowels and consonants and print out the result
    char smb;
    for(int sent = 1; (smb = getc(file)) != EOF; ++sent)
    {
        int vowel = 0, consonant = 0;
        while(smb != '.')
        {
            if(smb == 'a' || smb == 'e' || smb == 'y' || smb == 'u' || smb == 'i' || smb == 'o' ||
               smb == 'A' || smb == 'E' || smb == 'Y' || smb == 'U' || smb == 'I' || smb == 'O')
                ++vowel;
            else
            {
                if(isalpha(smb) != 0)
                    ++consonant;
            }
            smb = getc(file);
        }
        printf("[%d] sent. - %2d vow, %2d cons.\n", sent, vowel, consonant);
    }
    return 0;
}

void showFile(FILE *file)
{
    char str[MAX_SIZE];
    int i = 0;
    while ((str[i] = fgetc(file)) != EOF)
    {
		if (str[i] == '\n')
		{
			str[i] = '\0';
			printf("%s\n", str);
			i = 0;
		}
		else i++;
	}
	str[i] = '\0';
	printf("%s\n", str);
}
