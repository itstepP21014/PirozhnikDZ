#include "fraction.h"
#include <iostream>

using namespace std;

int main()
{
    Fraction a(2, 3);
    a.print();
    Fraction b(7, 4);
    b.print();
    Fraction c(14, 5);
    c.print();

    a = a / b;
    a.print();
    if(b == c)
        cout << "b == c" << endl;
    else
        cout << "b != c" << endl;

    // getc(stdin);
    //cout << "Hello World!" << endl;
    return 0;
}

