#include <stdio.h>
#include <stdlib.h>

char mas[3][3]={{' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', ' '}};

void display()
{
    for(int i=0; i<5; i++){
        if(i%2==0) printf("%c|%c|%c\n",mas[i/2][0],mas[i/2][1], mas[i/2][2]);
        else printf("-----\n");
    }
}

void player()
{
    int stroka, stolbec, oshibka=1;
    static int smena_igroka=1;
    do{
        printf("Vvedite # stroki i # stolbca:\n");
        scanf("%d%d", &stroka, &stolbec);
        if(mas[stroka-1][stolbec-1]==' '){
            if(smena_igroka%2==0) mas[stroka-1][stolbec-1]='O';
            else mas[stroka-1][stolbec-1]='X';
        ++smena_igroka;
        oshibka=0;
        }else printf("Yachejka zanyata ili imeet ne vernye koordinaty! Poprobujte eshe.\n");
    }while(oshibka);
}

int is_there_winner()
{
    int proceed=1;
    int i=0;
    for(i; i<3; ++i){
        if(mas[i][0]==mas[i][1] && mas[i][1]==mas[i][2] && mas[i][0]!=' '){
            proceed=0;
            if(mas[i][0]=='X') return 1;
            else return 2;
        }
    }
    for(i; i<3; ++i){
        if(mas[0][i]==mas[1][i] && mas[1][i]==mas[2][i] && mas[0][i]!=' '){
            proceed=0;
            if(mas[0][i]=='X') return 1;
            else return 2;
        }
    }
    if((mas[0][0]==mas[1][1] && mas[1][1]==mas[2][2]) || (mas[0][2]==mas[1][1] && mas[1][1]==mas[2][0])){
        proceed=0;
        if(mas[1][1]=='X') return 1;
        else return 2;
    }
    if(proceed) return 0;
}

void res(int n)
{
    if(n!=0){
        if(n==1){
            printf("Pobedil igrok #1!\nPozdravlyaem!\n");
            exit(1);
        }else {
            printf("Pobedil igrok #2!\nPozdravlyaem!\n");
            exit(1);
        }
    }
}


int main()
{
    display();
    for(int hod=1; hod<10; ++hod){
        player();
        display();
        if(hod>4) res(is_there_winner());
    }
    printf("Pobedila druzhba! :)\n");
    return 0;
}
