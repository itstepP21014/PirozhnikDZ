#include <stdio.h>
#include <stdlib.h>
#include "../../mylib/include/myfuns.h"

typedef struct Mix_fraction_ {
    int integer;
    int numerator;
    int denominator;
} Mix_fraction;

Mix_fraction input_fracNum(Mix_fraction number);
void output_fracNum(Mix_fraction number);
double convert_fracNum(Mix_fraction number);
Mix_fraction sum_fracNum(Mix_fraction a, Mix_fraction b);
Mix_fraction subtract_fracNum(Mix_fraction a, Mix_fraction b);
Mix_fraction multip_fracNum(Mix_fraction a, Mix_fraction b);
Mix_fraction divide_fracNum(Mix_fraction a, Mix_fraction b);

Mix_fraction input_fracNum(Mix_fraction number)
{
    printf("Vvedite celoe chislo, chislitel i znamenatel.\n");
    scanf("%d %d %d", &number.integer, &number.numerator, &number.denominator);
    return number;
}

void output_fracNum(Mix_fraction number)
{
    if(number.integer != 0)
        printf("%d/%d\n", number.numerator, number.denominator);
    else
        printf("%d %d/%d\n", number.integer, number.numerator, number.denominator);
}

double convert_fracNum(Mix_fraction number)
{
    double result = (number.numerator / number.denominator) + number.integer;
    return result;
}

Mix_fraction sum_fracNum(Mix_fraction a, Mix_fraction b)
{
    Mix_fraction result;
    a.numerator = a.numerator + (a.integer * a.denominator);
    b.numerator = b.numerator + (b.integer * b.denominator);

    result.numerator = (a.numerator * b.denominator) + (b.numerator * a.denominator);
    result.denominator = a.denominator * b.denominator;

    result.integer = result.numerator / result.denominator;
    if(result.integer != 0)
        result.numerator = result.numerator - (result.denominator * result.integer);
    int div = gcd(result.numerator, result.denominator);
    result.numerator/=div;
    result.denominator/=div;
    return result;
}

Mix_fraction subtract_fracNum(Mix_fraction a, Mix_fraction b)
{
    Mix_fraction result;
    a.numerator = a.numerator + (a.integer * a.denominator);
    b.numerator = b.numerator + (b.integer * b.denominator);

    result.numerator = (a.numerator * b.denominator) - (b.numerator * a.denominator);
    result.denominator = a.denominator * b.denominator;

    result.integer = result.numerator / result.denominator;
    if(result.integer != 0)
        result.numerator = result.numerator - (result.denominator * result.integer);
    int div = gcd(result.numerator, result.denominator);
    result.numerator/=div;
    result.denominator/=div;
    return result;
}


Mix_fraction multip_fracNum(Mix_fraction a, Mix_fraction b)
{
    Mix_fraction result;
    a.numerator = a.numerator + (a.integer * a.denominator);
    b.numerator = b.numerator + (b.integer * b.denominator);

    result.numerator = a.numerator * b.numerator;
    result.denominator = a.denominator * b.denominator;

    result.integer = result.numerator / result.denominator;
    if(result.integer != 0)
        result.numerator = result.numerator - (result.denominator * result.integer);
    int div = gcd(result.numerator, result.denominator);
    result.numerator/=div;
    result.denominator/=div;
    return result;
}

Mix_fraction divide_fracNum(Mix_fraction a, Mix_fraction b)
{
    Mix_fraction result;
    a.numerator = a.numerator + (a.integer * a.denominator);
    b.numerator = b.numerator + (b.integer * b.denominator);

    result.numerator = a.numerator * b.denominator;
    result.denominator = a.denominator * b.numerator;

    result.integer = result.numerator / result.denominator;
    if(result.integer != 0)
        result.numerator = result.numerator - (result.denominator * result.integer);
    int div = gcd(result.numerator, result.denominator);
    result.numerator/=div;
    result.denominator/=div;
    return result;
}


int main()
{
    Mix_fraction fraction1, fraction2;
    input_fracNum(fraction1);
    output_fracNum(fraction1);
    input_fracNum(fraction2);
    output_fracNum(fraction2);
    printf("Summa:\n");
    output_fracNum(sum_fracNum( fraction1,  fraction2));
    printf("Vychitanie:\n");
    output_fracNum(subtract_fracNum( fraction1,  fraction2));
    printf("Umnozhenie:\n");
    output_fracNum(multip_fracNum( fraction1,  fraction2));
    printf("Delenie:\n");
    output_fracNum(divide_fracNum( fraction1,  fraction2));
    printf("Konvertaciya:\n");
    printf("%.4f\n", convert_fracNum(fraction1));
    return 0;
}
