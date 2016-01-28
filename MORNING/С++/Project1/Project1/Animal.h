#pragma once
#include <string>
using namespace std;

class Animal  // объявляем класс животное
{
protected: // чтобы было в доступе только для класса и его наследников
	string name; // объявляем переменную имя
public: // в доступе всему
	// конструктор
	Animal(string name_); // обязательно с указанием имени

	// деструктор
	~Animal();

	virtual void voice();
};

