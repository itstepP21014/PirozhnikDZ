#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    printf("***    Simpletron privetstvuet Vas!                                  ***\n"
           "*** Pozhaluysta, vvedite Vashu programmu po odnoy komande za raz.    ***\n"
           "*** Ya budu vivodit' v kachestve podskazki tekushiy adres i znak     ***\n"
           "*** voprosa (?). Vvedennoe Vami slovo budet razmesheno po ukazannomu ***\n"
           "*** adresu. Dlya prekrashenya programmy vvedite chislo -99999.       ***\n\n");
    int instructionCounter=-1;
    int *memory=NULL;
    do{
        ++instructionCounter;
        printf("%02d ? ", instructionCounter);
        scanf("%d", &memory[instructionCounter]);
    }while(memory[instructionCounter]!=(-99999));
    printf("\n*** Zagruska programmy zavershena  ***\n"
           "*** Nachinayu vypolnenie programmy ***\n");
    int lengthOfProgramm=instructionCounter-1;
    memory=(int*)malloc(lengthOfProgramm*sizeof(int));
    int accumulator;
    for(int instructionCounter=0; instructionCounter<lengthOfProgramm; ++instructionCounter){
        int instructionRegister=memory[instructionCounter];
        int operationCode=instructionRegister/100;
        int operand=instructionRegister%100;
        switch(operationCode)
        {
        case 10: printf("\nVvedite chislo:\n");
                 scanf("%d", &memory[operand]);
                 break;
        case 11: printf("\nOtvet: %d\n", memory[operand]);
                 break;
        case 20: accumulator=memory[operand];
                 break;
        case 21: memory[operand]=accumulator;
                 break;
        case 30: accumulator+=memory[operand];
                 break;
        case 31: accumulator-=memory[operand];
                 break;
        case 32: accumulator/=memory[operand];
                 break;
        case 33: accumulator*=memory[operand];
                 break;
        case 40: instructionCounter=operand-1;
                 break;
        case 41: if(accumulator<0) instructionCounter=operand-1;
                 break;
        case 42: if(accumulator==0) instructionCounter=operand-1;
                 break;
        case 43: return 0;
                 break;
        }
    }
    free(memory);
    memory=NULL;
}
