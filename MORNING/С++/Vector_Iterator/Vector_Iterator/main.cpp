#include "Vector.h"
#include <iostream>

using namespace std;

int main()
{
	int c[3] = { 1, 2, 3 };
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