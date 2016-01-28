#include <new>
#include <iostream>
//#include <conio.h>
//#include <new>
#include <string>
#include "vector.h"
#include "list.h"

using namespace std;
/*
class A{
public:
	std::string x;
};
*/
int main()
{
	List<int> a_int;

	for (int i = 0; i < 7; i++)
		a_int.PushFront(i);

	auto p = a_int.find(4);
	if (p == a_int.end()) {
		cout << "value not found!\n";
		return 0;
	}

	a_int.erase(p);

	for (auto q = a_int.begin(); q != a_int.end(); ++q) {
		cout << *q << endl;
	}

	sort(a_int.begin(), a_int.end());

	for (auto q = a_int.begin(); q != a_int.end(); ++q) {
		cout << *q << endl;
	}

	getc(stdin);
	return 0;
}