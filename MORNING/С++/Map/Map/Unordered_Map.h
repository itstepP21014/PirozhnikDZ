#pragma once
#include <iostream>
#include <list>

using namespace std;

template <class Tkey, class Tvalue>
class Unordered_Map {
private:
	struct pair {
		pair(Tkey k, Tvalue v) : key(k), value(v) {};
		Tkey key;
		Tvalue value;
	};

	list<pair> pairs;

public:
	Unordered_Map() {}
	~Unordered_Map() {}
	Tvalue& operator[] (const Tkey& key) {
		for (auto i = pairs.begin(); // i указывает на начало списка пар
			i != pairs.end(); // повторяем пока i не начнет указывать на конец списка
			++i) {

			if (i->key == key) {
				return i->value;
			}
		}
		pairs.push_back(
			
			pair(key, Tvalue() )
			
		);
		return pairs.back().value;
	}

	void show() {
		/*
		for (auto i = pairs.begin(); i != pairs.end(); i++)
		{
			cout << i->key << " -> " << i->value << endl;
		}
		*/
		for (auto pair : pairs) {
			cout << pair.key << " -> " << pair.value << endl;
		}
	}



};