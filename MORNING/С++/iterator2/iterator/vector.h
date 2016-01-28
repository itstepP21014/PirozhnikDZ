#pragma once
#include <exception>
#include <stdexcept>

using namespace std;

template <class T>
class Vector{
private:
	T *elements;
	size_t size;
	int memory;

public:

	class iterator {
	public:
		T *current;
		Vector *host;
	public:
		iterator(T* arg, Vector *host_) : current(arg), host(host_) {};
		iterator() : current(nullptr), host(nullptr) {};
		T & operator*() {
			if (current == nullptr) {
				throw invalid_argument("In List::iterator::operator*() : invalid iterator");
			}
			return *current;
		}
		iterator& operator++() {
			if (current == nullptr) {
				throw invalid_argument("In List::iterator::operator++() : invalid iterator");
			}
			current += 1;
			return (*this);
		}
		bool operator==(const iterator &i) const{
			return current == i.current;
		}
		bool operator!=(const iterator &i) const{
			return current != i.current;
		}

	};

	Vector(){
		size = 0;
		elements = nullptr;
	}
	Vector(size_t size){
		this->size = size;
		elements = (T*)malloc(size * sizeof(T));
	}
	Vector(size_t size, int n){
		this->size = size;
		elements = (T*)malloc(size * sizeof(T));
		for (size_t i = 0; i < size; ++i){
			elements[i] = n;
		}
	}
	~Vector(){
		free(elements);
	}

	void PushBack(T n) {
		++size;
		elements = (T*)realloc(elements, sizeof(T)* size);
		elements[size - 1] = n;
	}
	void PopBack() {
		if (size == 0){
			cout << "ERROR!";
			exit(1);
		}
		--size;
		elements = (T*)realloc(elements, sizeof(T)* size);
	}
	void PushFront(T n) {
		++size;
		elements = (T*)realloc(elements, sizeof(T)* size);
		memmove(elements + 1, elements, (size - 1) * sizeof(T));
		elements[0] = n;
	}
	void PopFront() {
		if (size == 0){
			cout << "ERROR!";
			exit(1);
		}
		--size;
		elements = (T*)realloc(elements, sizeof(T)* size);
		memmove(elements - 1, elements, (size - 1) * sizeof(T));
	}

	void print() {
		for (size_t i = 0; i < size; ++i){
			cout << elements[i] << " ";
		}
		cout << endl;
	}

	double& operator[](size_t index) {
		if (index >= size){
			cout << "ERROR!";
			exit(2);
		}
		return elements[index];
	}

	iterator find(const T& value) {
		T* temp = elements;
		for (size_t i = 0; i < size; ++i) {
			if (*temp == value) {
				return iterator(temp, this);
			}
			++temp;
		}
		return iterator(nullptr, this);
	}
	Vector& erase(iterator &it) {
		if (size == 0)
			throw invalid_argument("In Vector::iterator::erase() : invalid iterator");

		if (memory / size == 2) {
			memory /= 2;
			elements = (T*)realloc(elements, memory * sizeof(T));
		}
		memmove(it.current, it.current + 1, (elements + size - it.current)*sizeof(T));

		--size;
		return (*this);
	}

	iterator begin() {
		return iterator(elements, this);
	}
	iterator end() {
		return iterator(elements + size, this);
	}

};

template <class A>
void sort(A begin, A end) {
	for (A i = begin; i != end; i++) {
		for (A j = begin;; ) {
			A tmp = j;
			j++;
			if (j == end) {
				break;
			}
			if (*tmp  > *j) {
				auto helper = *j;
				*j = *tmp;
				*tmp = helper;
			}
		}
	}
}