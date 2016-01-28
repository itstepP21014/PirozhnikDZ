#include "Cat.h"
#include "Dog.h"
#include "Animal.h"
#include <cstdio>

int main() {

	Cat thomas("Tommy"); // переменная томас класса кэт с именем Томми
	thomas.voice(); // приказываем переменной томас поодать голос

	Dog jerry("Jerry"); 
	jerry.voice(); 

	Animal *zoo[2] = {&thomas, &jerry};
	for (int i = 0; i < 2; ++i)
		zoo[i] -> voice();
		

	getc(stdin);

	return 0;
}