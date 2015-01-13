#include <stdio.h>
#include <stdlib.h>

// хкх ъ ядекюкю врн-рн ме рюй хкх бярюбкърэ гдеяэ тсмйжхч мер ялшякю

// бюпхюмр нашвмши:
// int main()
// {
//    char L;
//    printf("Enter 10 letters: ");
//    for(int i=1; i<=10; ++i){
//        scanf("%c", &L);
//        printf("%c\n", L);
//    }
//    return 0;
// }

//бюпхюмр я днонкмхрекэмни тсмйжхеи:
void printLetterColumn(char L);

int main()
{
    char L;
    printf("Enter 10 letters: ");
    for(int i=1; i<=10; ++i){
        scanf("%c", &L);
        printLetterColumn(L);
    }
    return 0;
}

void printLetterColumn(char L)
{
    printf("%c\n", L);
}
