#include <iostream>
#include <string>
#include "Cat.h"

using namespace std;

Cat::Cat(string name_) :
Animal(name_)
{

}

void Cat::voice() {
	cout << "Cat " << name << " says 'Meow !!!'\n";
}