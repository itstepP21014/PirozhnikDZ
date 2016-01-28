#include "Vector.h"
#include <iostream>

using namespace std;

int main()
{
	/*
	Vector a(0.23, 12.0, 2.3);
	a.print();
	Vector b(0.77, 1.0, 1.7);
	b.print();

	a += b;
	a.print();

	double sk = a.fusion(b);
	cout << sk << endl;
	*/

	Vector a(5, 7);
	a.print();
	a.push_front(8);
	a.print();
	a.pop_back();
	a.print();
	a.pop_front();
	a.print();
	a[2] = 1;
	a.print();
	

	getc(stdin);
	//cout << "Hello World!" << endl;
	return 0;
}