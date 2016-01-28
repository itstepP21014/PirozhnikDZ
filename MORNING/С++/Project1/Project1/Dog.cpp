#include <iostream>
#include <string>
#include "Dog.h"

using namespace std;

Dog::Dog(string name_) :
Animal(name_)
{

}

void Dog::voice() {
	cout << "Dog " << name << " says 'Gow !!!'\n";
}