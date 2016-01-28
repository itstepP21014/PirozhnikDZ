#include "String.h"
#include <iostream>


int main(){
	/*
	String a('#', 7);
	String b = "Hello";

	String c = a; // String c(a); тоже самое     // вызов конструктора копирования
	b = a; // присваиваниe

	a.PrintStr();
	b.PrintStr();

	a.Plus(" world!");
	a.PrintStr();
	b.PrintStr();

	std::cout << "_________________\n";

	PrintStr(b);

	if (b.Find("lo")){
		std::cout << "lo is found in Hello!" << std::endl;
	}

	b.Plus(" world!");
	b.PrintStr();

	sqr(1 + 7 + 4 + 19);
	*/
	



	String a = "hello world";
	a.PrintStr();
	String b = "Hi, my friend!";
	b.PrintStr();
	String c = "  and zozolok!";
	c.PrintStr();
	printf("\n");

	a.UpperCase();
	a.PrintStr();

	String f = a.First(5);
	f.PrintStr();

	String l = c.Last(3);
	l.PrintStr();

	String g = b.GetSubstring(5, 2);
	g.PrintStr();

	String d = a.Pluss(c);
	d.PrintStr();



	std::getc(stdin);
	return 0;
}