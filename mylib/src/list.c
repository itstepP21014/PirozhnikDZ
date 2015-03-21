#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include "../../mylib/include/list.h"

// odnosvyaznie spiski

void addNode(Node **list, int data)
{
    Node *temp = NULL;
    temp = (Node *)malloc(sizeof(Node));
    if(!temp)
    {
        printf("There is no memory!\n");
        exit(-1);
    }
    temp -> data = data;
    temp -> next = NULL;
    if(*list)
        temp -> next = *list;
    *list = temp;
    temp = NULL;
}

void printList(const Node *list)
{
    if(!list)
        printf("List is empty.\n");
    else
    {
        while(list)
        {
            printf("%d-", list -> data);
            list = list -> next;
        }
        printf("//\n");
    }
}

int popNode(Node **list)
{
    int value;
    Node *temp = NULL;
    if(*list)
    {
        value = (*list) -> data;
        temp = *list;
        *list = (*list) -> next;
        free(temp);
        temp = NULL;
        return value;
    }
}

void deleteList(Node **list)
{
    while(*list)
        popNode(list);
}

void addNodeToEnd(Node **list, int data)
{
    Node *temp = NULL;
    temp = (Node *)malloc(sizeof(Node));
    if(!temp)
    {
        printf("There is no memory!\n");
        exit(-1);
    }
    temp -> data = data;
    temp -> next = NULL;
    Node *p = NULL;
    p = *list;
    if(!p)
        *list = temp;
    else
    {
        while(p -> next)
            p = p -> next;
        p -> next = temp;
    }
    temp = NULL;
}

int countNode(const Node *list)
{
    int count = 0;
    Node *temp = NULL;
    while(list)
    {
        temp = list -> next;
        list = temp;
        ++count;
    }
    return count;
}

bool isEmptyList(const Node *list)
{
    if(list)
        return true;
    return false;
}

// dvusvyaznie spiski

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
        exit(1);
    }
    temp = list -> first;
    list -> first = list -> first -> prev;
    if(list -> first)
        list -> first -> next = NULL;
    if(temp == list -> last)
        list -> last = NULL;
    data = temp -> data;
    --(list -> size);
    free(temp);
    temp = NULL;
    return data;
}

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
        list -> first = NULL;
    data = temp -> data;
    --(list -> size);
    free(temp);
    temp = NULL;
    return data;
}

void delDoubleList(List *list)
{
    while(list)
        popInFront(list);
}
