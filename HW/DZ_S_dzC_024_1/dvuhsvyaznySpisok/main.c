#include <stdio.h>
#include <stdlib.h>
#include "../../mylib/include/list.h"

int main()
{
    List *list = NULL;
    initDoubleList(&list);
    pushInFront(list, 333);
    pushInFront(list, 4444);
    pushInBack(list, 22);
    pushInBack(list, 1);
    printf("%d \n", list -> last -> data);
    printf("%d \n", list -> first -> data);
    printf("%d \n", popInFront(list));
    printf("%d \n", popInBack(list));
    printf("%d \n", list -> first -> data);
    printf("%d \n", list -> last -> data);
    delDoubleList(list);
    return 0;
}
