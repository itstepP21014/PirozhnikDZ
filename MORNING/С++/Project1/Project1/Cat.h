#pragma once
#include "Animal.h"
#include <string>
using namespace std;

class Cat : public Animal { // ��������� ����� ������
public: // ������� ��������� ��� ����
	Cat(string name);
	virtual void voice();
};