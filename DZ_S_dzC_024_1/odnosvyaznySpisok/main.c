#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include "../../mylib/include/list.h"

int main()
{
    Node *list = NULL;
    addNode(&list, 3);
    addNode(&list, 22);
    addNode(&list, 333);
    addNode(&list, 4444);
    printList(list);
    printf("%d \n", countNode(list));
    printf("%d \n", popNode(&list));
    printList(list);
    deleteList(&list);
    printList(list);
    addNode(&list, 202);
    addNode(&list, 303);
    printList(list);
    addNodeToEnd(&list, 101);
    printList(list);
    printf("%d \n", countNode(list));
    if(isEmptyList(list))
        printf("List exists!\n");
    else
        printf("List is  empty!\n");
    return 0;
}
