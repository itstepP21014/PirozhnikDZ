#include "Cat.h"
#include "Dog.h"
#include "Animal.h"
#include <cstdio>

int main() {

	Cat thomas("Tommy"); // ���������� ����� ������ ��� � ������ �����
	thomas.voice(); // ����������� ���������� ����� ������� �����

	Dog jerry("Jerry"); 
	jerry.voice(); 

	Animal *zoo[2] = {&thomas, &jerry};
	for (int i = 0; i < 2; ++i)
		zoo[i] -> voice();
		

	getc(stdin);

	return 0;
}