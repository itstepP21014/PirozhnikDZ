#pragma once
#include "Animal.h"
#include <string>
using namespace std;

class Dog : public Animal { // наследуем класс анимал
public: // область видимости для всех
	Dog(string name);
	virtual void voice();
};