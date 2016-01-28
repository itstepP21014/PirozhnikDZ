
#include "Iterator.h"
#include <iostream>
#include <conio.h>
#include <new>



using namespace std;
int main()
{
	List a_int(sizeof(int));

	for (int i = 0; i < 7; i++)
		a_int.PushFront((void*)i);

	List::Node* i = a_int.find((void*)4);

	while (i != nullptr) {
		cout << ((int)i->data) << endl;
		i = i->next;
	}

	int size_a = a_int.ElementCount();
	cout << "element count in a_int = " << size_a << endl;
	a_int[6]->data = (void*)20;
	for (int i = 0; i < size_a; i++)
		cout << (int)a_int[i]->data << ' ';

	_getch();
	return 0;
}