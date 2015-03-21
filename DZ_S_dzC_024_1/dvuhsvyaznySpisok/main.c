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
int popInFront(List *list);
int popInBack(List *list);

int main()
{
    List *list = NULL;
    initDoubleList(&list);
    pushInFront(list, 333);
    pushInFront(list, 4444);
    pushInBack(list, 22);
    pushInBack(list, 1);
<<<<<<< HEAD
    printf("%d \n", list -> last -> data);
    printf("%d \n", list -> first -> data);
    printf("%d \n", popInFront(list));
    printf("%d \n", popInBack(list));
=======
    printf("%d \n", list -> first -> data);
    popInFront(list);
    printf("%d \n", list -> first -> data);
    popInBack(list);
    printf("%d \n", list -> last -> data);

>>>>>>> 552162c2c4916da331241b75643309fc02c2d6e3
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

int popInFront(List *list)
{
    int data;
    DoubleNode *temp;
    if(!list -> first)
    {
        printf("ERROR! There is no any list.\n");
<<<<<<< HEAD
        exit(1);
    }
    temp = list -> first;
    list -> first = list -> first -> prev;
    if(list -> first)
        list -> first -> next = NULL;
    if(temp == list -> last)
        list -> last = NULL;
    data = temp -> data;
=======
        exit(2);
    }
    temp = list -> first;
    if(!list -> first -> prev)
        list -> first = list -> last = NULL;
    temp = list -> first -> prev;
    temp -> next = NULL;
    list -> first = temp;
>>>>>>> 552162c2c4916da331241b75643309fc02c2d6e3
    --(list -> size);
    free(temp);
    temp = NULL;
}

<<<<<<< HEAD
int popInBack(List *list)
{
    int data;
    DoubleNode *temp;
    if(!list -> last)
    {
        printf("ERROR! There is no any list.\n");
        exit(1);
    }
    temp = list -> last;
    list -> last = list -> last -> next;
    if(list -> last)
        list -> last -> prev = NULL;
    if(temp == list -> last)
        list -> last = NULL;
    data = temp -> data;
=======
void popInBack(List *list)
{
    DoubleNode *temp;
    if(!list -> first)
    {
        printf("ERROR! There is no any list.\n");
        exit(2);
    }
    temp = list -> last;
    if(!list -> last -> next)
        list -> last = list -> first = NULL;
    temp = list -> last -> next;
    temp -> prev = NULL;
    list -> last = temp;
>>>>>>> 552162c2c4916da331241b75643309fc02c2d6e3
    --(list -> size);
    free(temp);
    temp = NULL;
}
