#ifndef LIST_H_INCLUDED
#define LIST_H_INCLUDED

typedef struct Node_
{
    int data;
    struct Node_ *next;
} Node;

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

void addNode(Node **list, int data);
void printList(const Node *list);
int popNode(Node **list);
void deleteList(Node **list);
void addNodeToEnd(Node **list, int data);
int countNode(const Node *list);
bool isEmptyList(const Node *list);

void initDoubleList(List **list);
void pushInFront(List *list, int data);
void pushInBack(List *list, int data);
int popInFront(List *list);
int popInBack(List *list);
void delDoubleList(List *list);

#endif // LIST_H_INCLUDED
