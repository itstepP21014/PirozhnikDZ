#include "Double_List.h"
#include <iostream>

using namespace std;

int main() {
	
	Double_List l;
	try {
		l.push_front(1234).push_front(12).push_front(41);
	}
	catch (int e){
		cout << "Error: get memorry\n";
	}
		
	l[0] = 2;

	l[1] = 333;

	for (size_t i = 0; i < l.getSize(); ++i){
		cout << l[i] << endl;
	}
	getc(stdin);
	return 0;
}