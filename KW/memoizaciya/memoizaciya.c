#include <stdlib.h>

int fibImpl(int *memory, int n)
{
    if(memory[n]<0)
        memory[n]=fibImpl(memory, n-1)+fibImpl(memory, n-2);
    return memory[n];
}

int fibonacci(int n)
{
    int *memory;
    memory=(int*)malloc((n+1)*sizeof(int));
    for(int i=0; i<=n; ++i)
    {
        memory[i]=-1;
    }
    memory[0]=0;
    memory[1]=1;
    int result=fibImpl(memory, n); // fibonacci implimitation (realizaciya)
    free(memory);
    return result;
}
