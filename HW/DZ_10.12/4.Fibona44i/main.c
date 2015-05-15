#include <stdio.h>
#include <stdlib.h>

int main()
{
    int kolichestvoChisel, a=1, b=0, resultat;
    printf("Vvedite zhelaemoe kolichestvo chisel: ");
    scanf("%d", &kolichestvoChisel);
    for(int i=1; i<=kolichestvoChisel; ++i)
    {
        resultat=a+b;
        printf("%d ", resultat);
        a=b;
        b=resultat;
    }
    return 0;
}
