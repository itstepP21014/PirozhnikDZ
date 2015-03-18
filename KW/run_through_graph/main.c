#include <stdio.h>
#include <stdlib.h>

typedef struct Node_
{
    int versh;
    struct Node_ *link;
} Node;

void add_versh(Node **list, int versh);
void print_list(const Node *list);
void clean_list(Node **list);

int main()
{
    FILE *file;
    int versh, rebra;
    file = fopen("graf.txt", "r");
    if(file == NULL)
        printf("Error!\n");
    fscanf(file, "%d %d",  &versh, &rebra);
    Node **mas=NULL;
    mas=(Node **)malloc(versh*sizeof(Node *));
    for(int i=0; i < versh; ++i)
        mas[i] = NULL;
    for(int i=0; i < rebra; ++i)
    {
        int a, b;
        fscanf(file, "%d %d", &a, &b);
        add_versh(&mas[a-1], b-1);
        add_versh(&mas[b-1], a-1);
    }

    for(int i=0; i < versh; ++i)
    {
        printf("%d: ", i+1);
        print_list(mas[i]);
        printf("\n");
    }

    for(int i=0; i < versh; ++i)
        clean_list(&mas[i]);
    free(mas);
    mas = NULL;
    return 0;
}

void add_versh(Node **list, int versh)
{
    Node *p=NULL;
    p=(Node *)malloc(sizeof(Node));
    p->versh = versh;
    p->link = *list;
    *list = p;
}

void print_list(const Node *list)
{
    while(list)
    {
        printf("%d ", list->versh + 1);
        list = list->link;
    }
}

void clean_list(Node **list)
{
    while(*list)
    {
        Node *p = *list;
        *list = (*list)->link;
        free(p);
        p = NULL;
    }
}
