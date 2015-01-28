int random()
{
    static int x=1, a=4098, c=150889, m=714025;
    x=((a*x)+c)%m;
    return x;
}
