#include "String.h"
#include <cstdio>

int main()
{
	String a=" World";
	String b = "Hello";
	String c = "Hell";

	printf("before print call\n");

	print(b); // вызов функции

	printf("after print call\n");

	b.print(); // вызов метода
	a.print();



	b.plus(a);
	b.print();

	const char* n = b.find(c);
	if (n == nullptr)
		printf("Error\n");



	getc(stdin);
	
	return 0;
}