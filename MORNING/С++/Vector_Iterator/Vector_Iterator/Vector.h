#ifndef VECTOR_H
#define VECTOR_H

#include <cstdlib>
#include <stdexcept>

using namespace std;

class Vector{
private:
	double *elements;
	size_t size;

public:

	class iterator {
	private:
		double *current;
		double *first, *last;
	public:
		iterator(double* arg, double* frst, double* lst) : current(arg) {};
		double & operator*() {
			if ((current > first) && (current < last)) {
				return *current;
			}
			else throw invalid_argument("In Vector::iterator::operator*() : invalid iterator\n");
		}
		iterator& operator++() {
			if (current != last) {
				current = current + 1;
				return (*this);
			}
			else throw invalid_argument("In Vector::iterator::operator++() : invalid iterator\n");
		}
	};

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