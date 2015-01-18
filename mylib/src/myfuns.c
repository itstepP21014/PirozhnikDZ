int gcd(int a, int b)
{
    if(b==0){return a;}
    else{
        while(a%b!=0){
            int c=a%b;
            a=b;
            b=c;
        }
        return b;
    }
}

int lcm(int a, int b)
{
    int summ=a*b;
    return summ/(gcd(a, b));
}
