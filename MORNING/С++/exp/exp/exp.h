#include <ctime>
#include <random>
#include <iostream>
#include <ratio>
#include <chrono>
#include <list>
#include <fstream>
#include <map>
#include "Hash.h"

using namespace std::chrono;

// добавляем данные в массив
int add_in_array(int *random, int size) {
	std::cout << "Locating array of " << size << " itens...\n";
	system_clock::time_point start = system_clock::now();
	int *arr = new int[size];
	for (size_t i = 0; i <= size; ++i) {
		arr[i] = random[i];
	}
	//delete[] arr;
	system_clock::time_point located = system_clock::now();
	milliseconds ms = duration_cast<std::chrono::milliseconds> (located - start); // перевод в милисекунды
	std::cout << "Located (" << ms.count() << " ms).\n";
	return ms.count();
}