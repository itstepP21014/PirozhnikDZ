#include "List.h"
#include <iostream>

using namespace std;

int main() {

	List l;
	l.push_front(1234).push_front(12).push_front(41).push_back(333);
	l[1] = 2;
	for (size_t i = 0; i < l.getSize(); ++i){
		cout << l[i] << endl;
	}
	getc(stdin);
	return 0;
}