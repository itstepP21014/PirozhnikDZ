#pragma once
#include <iostream>
#include <list>
#include "Unordered_Map.h"

template <class Tkey, class Tvalue>
class Hash_Map {
private:
	Unordered_Map<Tkey, Tvalue> **arr;
	size_t size;
public:
	// � ������������ �������� ���������� ������ �� 3 * N UnorderedMap *
	Hash_Map(size_t size_) {
		size = 3 * size_;
		arr = new Unordered_Map<Tkey, Tvalue> * [size];
		for (size_t i = 0; i < size; ++i) {
			arr[i] = nullptr; // ��������� ������ nullptr
		}
	};
	~Hash_Map() {
		//for (;;) {}
		delete[] arr;
	}

	
	Tvalue& operator[](Tkey key) {
		unsigned int d = digest(key)% size;
		//arr[d % (N * 3)] - ���� ��� ���� ������� unorderedMap, else ���������� � unorderedMap
		if (arr[d ] == nullptr) {
			arr[d ] = new Unordered_Map<Tkey, Tvalue>;
		}
		return (
			
			*( // �������������� �������
			
			arr[d] // ���������� � ������������ �������� �������
			
			)
			
			)[key]; // ���������� � UnorderedMap
	}

	void show() {
		for (size_t i = 0; i < size; ++i)
		if (arr[i] != nullptr)
			(arr[i])->show();
	}

	Tkey& find(Tvalue value) {
		Tkey temp;
		for (size_t i = 0; i < size; ++i) {
			if (arr[i] != nullptr) {
				temp = arr[i]->find(value);
				if (temp != nullptr) {
					return temp;
				}
			}
		}
	}

};

template <class T>
int digest(T key); // ������� ��������� ������� ��� ����������������
unsigned int digest(string key) { // ������� ����� �����
	unsigned int sum = 0;
	for (auto i = 0; i < key.size(); ++i)
		sum += key[i];
	return sum;
}
