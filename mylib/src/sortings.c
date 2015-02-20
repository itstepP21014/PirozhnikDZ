int check_sorting(const int mas[], int size)
{
    for(int i=0; i<size-1; ++i)
        if(mas[i]>mas[i+1]) return 0;
    return 1;
}

void buble_sorting(int mas[], int size)
{
    while(!check_sorting(mas, size))
    {
        for(int i=0; i<size; ++i)
        {
            if(mas[i]>mas[i+1])
            {
                int x=mas[i];
                mas[i]=mas[i+1];
                mas[i+1]=x;
            }
        }
    }
}

void selection_sorting(int mas[], int size)
{
    for(int i=0; i<size-1; ++i)
    {
        int k;
        int min=mas[i];
        for(int j=i+1; j<size; ++j)
        {
            if(mas[j]<min)
            {
                min=mas[j];
                k=j;
            }
        }
        int x=mas[k];
        mas[k]=mas[i];
        mas[i]=x;
    }
}
