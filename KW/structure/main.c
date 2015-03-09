#include <stdio.h>
#include <stdlib.h>
#include <assert.h>
#include <../../mylib/include/myfuns.h> // for gcd

typedef struct Fraction_
{
    int numerator, denominator;
}Fraction;

Fraction sum(Fraction a, Fraction b)
{
    assert(a.denominator>0);
    assert(b.denominator>0);
    Fraction result;
    result.numerator=a.numerator*b.denominator+b.numerator*a.denominator;
    result.denominator=a.denominator*b.denominator;
    int div=gcd(result.numerator, result.denominator);
    result.numerator/=div;
    result.denominator/=div;
    return result;
}

int main()
{
    printf("Hello world!\n");
    return 0;
}
