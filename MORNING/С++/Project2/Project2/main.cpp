#include "String.h"
#include <cstdio>

int main()
{
	String a=" World";
	String b = "Hello";
	String c = "Hell";

	printf("before print call\n");

	print(b); // ����� �������

	printf("after print call\n");

	b.print(); // ����� ������
	a.print();



	b.plus(a);
	b.print();

	const char* n = b.find(c);
	if (n == nullptr)
		printf("Error\n");



	getc(stdin);
	
	return 0;
}