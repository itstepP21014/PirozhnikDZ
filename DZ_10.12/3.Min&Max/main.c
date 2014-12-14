#include <stdio.h>
#include <stdlib.h>

int main()
{
    int kolichestvoChisel, chislo, min, max=1;
    printf("Vvedite zhelaemoe kolichestvo chisel: ");
    scanf("%d", &kolichestvoChisel);
    printf("Vvedite %d chisel: ", kolichestvoChisel);
    for(int i=1; i<=kolichestvoChisel; ++i)
    {
        scanf("%d", &chislo);
        if(chislo>max)
        {
            max=chislo;
        }
        else
        {
            if(chislo<=min)
            {
                min=chislo;
            }
        }
    }
    printf("Chislo MAX = %d\nChislo MIN = %d\n", max, min);
    return 0;
}
