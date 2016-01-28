#ifndef FRACTION_H
#define FRACTION_H

#include <cstdbool>
#include <iostream>

class Fraction {
public:
	int ntor; // numerator
	unsigned int dtor; // denominator

	Fraction operator+ ();
	Fraction operator- ();
	Fraction operator+ (const Fraction& n) const;
	Fraction operator- (const Fraction& n) const;
	Fraction operator+= (const Fraction& n);
	Fraction operator-= (const Fraction& n);
	Fraction operator* (const Fraction& n) const;
	Fraction operator/ (const Fraction& n) const;
	Fraction operator*= (const Fraction& n);
	Fraction operator/= (const Fraction& n);

	Fraction convert();

	bool operator== (const Fraction& n) const;
	bool operator!= (const Fraction& n) const{
		return !(*this == n);
	}
	bool operator< (const Fraction& n) const;
	bool operator>(const Fraction& n) const{
		return n < (*this);
	}
	bool  operator>= (const Fraction& n) const{
		return !((*this) < n);
	}
	bool  operator<= (const Fraction& n) const{
		return !(n < (*this));
	}

	void print() const;

	int gcd();

	Fraction();
	Fraction(int n, unsigned int d);
	Fraction(int n);
	~Fraction();
};

std::ostream& operator<< (std::ostream& s, const Fraction& a);

#endif // FRACTION_H