#include <ctime>
#include <random>
#include <iostream>
#include <ratio>
#include <chrono>
#include <list>
#include <fstream>
#include <map>
#include "Hash.h"
#include "exp.h"

using namespace std::chrono;
const int N_MAX = 0x4000; // 2 в 26 степени

int main()
{
	srand(time(nullptr));
	int *arr_rand = new int[N_MAX];
	for (size_t i = 0; i <= N_MAX; ++i) {
		arr_rand[i] = rand();
	}

	ofstream fs("C:\\Users\\1\\Contacts\\Documents\\list.csv");

	for (int NN = 0x1000; NN <= N_MAX; NN*=2)
	{
		int ms_array = add_in_array(arr_rand, NN);
	
		// добавляем данные в список
		std::cout << "Locating list of " << NN  <<" items...\n";
		system_clock::time_point start_list = system_clock::now();
		{
			list<int> l;
			for (size_t i = 0; i <= NN; i++) {
				l.push_front(arr_rand[i]);
			}
		}
		system_clock::time_point list_located = system_clock::now();
		milliseconds ms_list = duration_cast<std::chrono::milliseconds> (list_located - start_list);
		std::cout << "Located (" << ms_list.count() << " ms).\n";

		// добавляем данные в дерево
		std::cout << "Locating map of " << NN << " items...\n";
		system_clock::time_point start_map = system_clock::now();
		{
			map<int, int> m;
			for (size_t i = 0; i <= NN; i++) {
				m[i] = arr_rand[i];
			}
		}
		system_clock::time_point map_located = system_clock::now();
		milliseconds ms_map = duration_cast<std::chrono::milliseconds> (map_located - start_map);
		std::cout << "Located (" << ms_map.count() << " ms).\n";

		// добавляем данные в хэш-таблицу
		std::cout << "Locating hash-table of " << NN << " items...\n";
		system_clock::time_point start_hash = system_clock::now();
		{
			Hash<int, int> h(NN);
			for (size_t i = 0; i <= NN; i++) {
				h[i] = arr_rand[i];
			}
		}
		system_clock::time_point hash_located = system_clock::now();
		milliseconds ms_hash = duration_cast<std::chrono::milliseconds> (hash_located - start_hash);
		std::cout << "Located (" << ms_hash.count() << " ms).\n";

		fs << NN << ";" << ms_array << ";" << ms_list.count() << ";" << ms_map.count() << ";" << ms_hash.count() << "\n";
	}
	fs.close();

	std::cout << "End\n";
	getc(stdin);
	return 0;
}