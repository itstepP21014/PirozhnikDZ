#include <stdio.h>
#include <stdlib.h>
#include "../../mylib/include/dice.h"

int main()
{
    int repeatGame, humanThrow, n;
    printf("Hello! Would You like to dice with me?\n(yes - press 1; no - don't be silly! let's play!)\n");
    scanf("%d", &repeatGame);
    do{
        system("cls");
        srand(time(NULL));
        int humanScore=0, computerScore=0;
        computerScore+=rand()%6+1;
        printf("My score:\n");
        n=computerScore;
        dice(n);
        printf("Your turn. To throw dice press 1.\n");
        scanf("%d", &humanThrow);
        if(humanThrow==1){
            humanScore+=rand()%6+1;
            printf("\nYour score:\n");
            n=humanScore;
            dice(n);
        }
        if(humanScore==computerScore){
            printf("\nDrawn game!\n");
        }
        else{
            if(humanScore<computerScore){
                printf("\nSorry, You lost!\n");
            }
            else{
                printf("\nCongratulate! You win!\n");
            }
        }
        printf("If You'd like to play again, press 1.\n");
        scanf("%d", &repeatGame);
    }while(repeatGame==1);
    return 0;
}
