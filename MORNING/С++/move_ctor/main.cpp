#include "String.h"
#include <iostream>


int main(){

	String a("a"), b("b"), c("c"), d;

	d = a + b + c; 

	PrintStr(d);

	std::getc(stdin);
	return 0;
}
