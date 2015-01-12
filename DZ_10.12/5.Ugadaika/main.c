#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    srand(time(NULL));
    int computerNumber, humanNumber, count, answer=1;
    do
    {
        system("cls");
        printf("Kompjuter zadumal chislo. Poprobujte ugadat'.\nVvedite chislo ot 1 do 99:\n");
        count=0;
        computerNumber=rand()%99+1;
        do
        {
            count+=1;
            scanf("%d", &humanNumber);
            if(humanNumber>computerNumber)
            {
                printf("Perebor! Poprobuyte snova:\n");
            }
            else
            {
                if(humanNumber<computerNumber)
                {
                    printf("Nedobor! Poprobuyte snova:\n");
                }
            }
        }while(computerNumber!=humanNumber);
        printf("Bingo!\nKolichestvo popytok - %d.\nHotite sygrat' eshe?\n(da - vvedite 1; net - vvedite 0)\n", count);
        scanf("%d", &answer);
    }while(answer==1);
    printf("Nu i zria!!!\n");
    return 0;
}
