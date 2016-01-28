#include "Vector.h"
#include <cstdlib>
#include <iostream>

using namespace std;

#include <cstring>

void Vector::push_back(double n){
	size += 1;
	elements = (double*)realloc(elements, sizeof(double)* size);
	elements[size - 1] = n;
}

void Vector::pop_back(){
	if (size == 0){
		cout << "ERROR!";
		exit(1);
	}
	size -= 1;
	elements = (double*)realloc(elements, sizeof(double)* size);
}

void Vector::push_front(double n){
	size += 1;
	elements = (double*)realloc(elements, sizeof(double)* size);
	memmove(elements + 1, elements, (size - 1) * sizeof(double));
	elements[0] = n;
}

void Vector::pop_front(){
	if (size == 0){
		cout << "ERROR!";
		exit(1);
	}
	size -= 1;
	elements = (double*)realloc(elements, sizeof(double)* size);
	memmove(elements - 1, elements, (size - 1) * sizeof(double));
}

void Vector::print(){
	for (size_t i = 0; i < size; ++i){
		cout << elements[i] << " ";
	}
	cout << endl;
}

double& Vector::operator[](size_t index){
	if (index >= size){
		cout << "ERROR!";
		exit(2);
	}
	return elements[index];
}