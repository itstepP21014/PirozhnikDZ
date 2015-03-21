#include <stdio.h>
#include <stdlib.h>

typedef struct DoubleNode_
{
    int data;
    struct DoubleNode_ *next;
    struct DoubleNode_ *prev;
} DoubleNode;

typedef struct List_
{
    int size;
    DoubleNode *first;
    DoubleNode *last;
} List;

void initDoubleList(List **list);
void pushInFront(List *list, int data);
void pushInBack(List *list, int data);
void popInFront(List *list);
void popInBack(List *list);

int main()
{
    List *list = NULL;
    initDoubleList(&list);
    pushInFront(list, 22);
    pushInFront(list, 333);
    pushInBack(list, 4444);
    printf("%d \n", list -> first -> data);
    popInFront(list);
    printf("%d \n", list -> first -> data);

    return 0;
}

void initDoubleList(List **list){
    List *temp = (List*)malloc(sizeof(List));
    temp -> size = 0;
    temp -> last = temp -> first = NULL;
    *list = temp;
}
void pushInFront(List *list, int data)
{
    DoubleNode *temp = NULL;
    temp = (DoubleNode *)malloc(sizeof(DoubleNode));
    if(!temp)
    {
        printf("There is no memory!\n");
        exit(-1);
    }
    temp -> data = data;
    temp -> next = NULL;
    temp -> prev = list -> first;
    if(list -> first)
        list -> first -> next = temp;
    list -> first = temp;
    if(!list -> first)
        list -> last = temp;
    ++(list -> size);
}

void pushInBack(List *list, int data)
{
    DoubleNode *temp = NULL;
    temp = (DoubleNode *)malloc(sizeof(DoubleNode));
    if(!temp)
    {
        printf("There is no memory!\n");
        exit(-1);
    }
    temp -> data = data;
    temp -> prev = NULL;
    temp -> next = list -> last;
    if(list -> last)
        list -> last -> prev = temp;
    list -> last = temp;
    if(!list -> last)
        list -> first = temp;
    ++(list -> size);
}

void popInFront(List *list)
{
    DoubleNode *temp;
    if(!list -> first)
    {
        printf("ERROR! There is no any list.\n");
        exit(2);
    }
    temp = list -> first;
    if(!list -> first -> prev)
        list -> first = list -> last = NULL;
    temp = list -> first -> prev;
    temp -> next = NULL;
    list -> first = temp;
}
