#include "Animal.h"
#include <iostream>
using namespace std;


Animal::Animal(string name_)
{
	name = name_;
	cout << "A new animal " << name << " appears!\n";
}


Animal::~Animal()
{
}

void Animal::voice() {

}