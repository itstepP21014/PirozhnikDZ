#include <stdio.h>
#include <stdlib.h>

// ��� � ������� ���-�� �� ��� ��� ��������� ����� ������� ��� ������

// ������� �������:
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

//������� � �������������� ��������:
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
