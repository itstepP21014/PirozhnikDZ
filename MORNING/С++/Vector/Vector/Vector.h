#ifndef VECTOR_H
#define VECTOR_H

/*
class Vector{
public:
	double x, y, z;

	Vector(){

	};
	Vector(double a, double b, double c){
		x = a;
		y = b;
		z = c;
	};
	~Vector(){

	};
	void operator+= (const Vector n);
	double fusion(const Vector n) const;
	void print() const;
};
*/

#include <cstdlib>

class Vector{
public:
	double *elements;
	size_t size;

	Vector(){
		size = 0;
		elements = nullptr;
	}
	Vector(size_t size){
		this->size = size;
		elements = (double*)malloc(size * sizeof(double));
	}
	Vector(size_t size, int n){
		this->size = size;
		elements = (double*)malloc(size * sizeof(double));
		for (size_t i = 0; i < size; ++i){
			elements[i] = n;
		}
	}

	~Vector(){
		free(elements);
	}

	void push_back(double n);
	void pop_back();
	void push_front(double n);
	void pop_front();
	void print();

	double& operator[](size_t index);
};

#endif // VECTOR_H