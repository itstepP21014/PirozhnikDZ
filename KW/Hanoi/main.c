#include <stdio.h>
#include <stdlib.h>

void diskTransfer(int disk, char from, char to, char helper);

int main()
{
    diskTransfer(5, 'a', 'b', 'c');
    return 0;
}

void diskTransfer(int disk, char from, char to, char helper)
{
    if(disk>0){ // if(disk>1)
        diskTransfer(disk-1, from, helper, to);
        printf("%c -> %c\n", from, to);
        diskTransfer(disk-1, helper, to, from);
    }
    // else{printf("%c -> %c\n", from, to);}
}
