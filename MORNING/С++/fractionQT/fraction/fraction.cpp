
#include "fraction.h"
#include <cstdlib>
#include <cstdio>
#include <iostream>
#include <cstdbool>

using namespace std;

Fraction Fraction::operator+ (){
    Fraction res(*this);
    if(res.ntor < 0)
        res.ntor *= (-1);
    return res;
}

Fraction Fraction::operator- (){
    Fraction res(*this);
    if(res.ntor > 0)
        res.ntor *= (-1);
    return res;
}

Fraction Fraction::operator+ (const Fraction& n) const{
    Fraction res(*this);
    int a, b;
    a = ntor * n.dtor;
    b = dtor * n.ntor;
    res.dtor = dtor * n.dtor;
    res.ntor = (a) + (b);
    return res;
}

Fraction Fraction::operator- (const Fraction& n) const{
    Fraction res(*this);
    int a, b;
    a = ntor * n.dtor;
    b = dtor * n.ntor;
    res.dtor = dtor * n.dtor;
    res.ntor = (a) - (b);
    return res;
}

Fraction Fraction::operator+= (const Fraction& n){
    int a, b;
    a = ntor * n.dtor;
    b = dtor * n.ntor;
    dtor = dtor * n.dtor;
    ntor = (a) + (b);
    return *this;
}

Fraction Fraction::operator-= (const Fraction& n){
    int a, b;
    a = ntor * n.dtor;
    b = dtor * n.ntor;
    dtor = dtor * n.dtor;
    ntor = (a) - (b);
    return *this;
}

Fraction Fraction::operator* (const Fraction& n) const{
    Fraction res(*this);
    res.dtor = dtor * n.dtor;
    res.ntor = ntor * n.ntor;
    return res;
}

Fraction Fraction::operator/ (const Fraction& n) const{
    Fraction res(*this);
    res.dtor = dtor * n.ntor;
    res.ntor = ntor * n.dtor;
    return res;
}

Fraction Fraction::operator*= (const Fraction& n){
    dtor = dtor * n.dtor;
    ntor = ntor * n.ntor;
    return *this;
}

Fraction Fraction::operator/= (const Fraction& n){
    dtor = dtor * n.ntor;
    ntor = ntor * n.dtor;
    return *this;
}

bool Fraction::operator== (const Fraction& n) const{
    Fraction a = (*this);
    Fraction b = n;
    a.convert();
    b.convert();
    if (a.ntor == b.ntor && a.dtor == b.dtor)
        return true;
    else return false;
}

bool Fraction::operator< (const Fraction& n) const{
    int a, b;
    a = ntor * n.dtor;
    b = dtor * n.ntor;
    if (a < b) return true;
    else return false;
}

void Fraction::print() const{
    cout << ntor << '/' << dtor << endl;
}

Fraction Fraction::convert(){
    int x = (*this).gcd();
    ntor /= x;
    dtor/= x;
    return *this;
}

int Fraction::gcd()
{
    if(dtor==0){return ntor;}
    else{
        while(ntor%dtor!=0){
            int x=ntor%dtor;
            ntor=dtor;
            dtor=x;
        }
        return dtor;
    }
}

Fraction::Fraction(){
    ntor = 0;
    dtor = 0;
};
Fraction::Fraction(int n, unsigned int d){
    ntor = n;
    dtor = d;
};
Fraction::Fraction(int n){
    ntor = n;
    dtor = 1;
};
Fraction::~Fraction()
{

}
