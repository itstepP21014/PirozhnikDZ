#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <assert.h>

#define MAX_STRING_SIZE 256

typedef enum Type_ {animalType, questionType} Type;

typedef struct Info_
{
    char stroka[MAX_STRING_SIZE];
    Type type;
} Info;

typedef struct Node_
{
    Info info;
    struct Node_ *yesLink, *noLink;
} Node;

void addNewKnowledge(Node *target, Info newAnimal, Info question, bool rightYesAnswer);
void createNode(Node **node, Info info);
Node *goToLeaf(Node *root);

int main()
{
    Node *root = NULL;
    Info catInfo = {"kot", animalType};
    createNode(&root, catInfo);
    Info whaleInfo = {"kit", animalType}, questionInfo = {"Ono bolshoe?", questionType};
    addNewKnowledge(root, whaleInfo, questionInfo, true);
    Node *target = goToLeaf(root);
    printf("Eto %s?\n", target -> info.stroka);
    return 0;
}

void createNode(Node **node, Info info)
{
    *node = (Node*)malloc(sizeof(Node));
    if(*node)
    {
        (*node) -> info = info;
        (*node) -> yesLink = NULL;
        (*node) -> noLink = NULL;
    }
}

void addNewKnowledge(Node *target, Info newAnimal, Info question, bool rightYesAnswer)
{
    assert(target);
    Info oldAnimal = target -> info;
    target -> info = question;
    Node *newAnimalNode, *oldAnimalNode;
    createNode(&newAnimalNode, newAnimal);
    createNode(&oldAnimalNode, oldAnimal);
    if(rightYesAnswer)
    {
        target -> yesLink = newAnimalNode;
        target -> noLink = oldAnimalNode;
    }
    else
    {
        target -> noLink = newAnimalNode;
        target -> yesLink = oldAnimalNode;
    }
}

Node *goToLeaf(Node *root)
{
    assert(root);
    Node *p = root;
    while(p -> info.type == questionType)
    {
        printf("%s\n", p -> info.stroka);
        printf("Y/N: ");
        char answer;
        scanf(" %c", &answer);
        if(answer == 'Y')
            p = p -> yesLink;
        else
            p = p -> noLink;
    }
    return p;
}
