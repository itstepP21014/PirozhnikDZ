int random()
{
    static int x=1, a=2398, c=456932462625, m=504007;
    x=((a*x)+c)%m;
    return x;
}
