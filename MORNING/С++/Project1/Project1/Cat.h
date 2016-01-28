#pragma once
#include "Animal.h"
#include <string>
using namespace std;

class Cat : public Animal { // наследуем класс анимал
public: // область видимости для всех
	Cat(string name);
	virtual void voice();
};