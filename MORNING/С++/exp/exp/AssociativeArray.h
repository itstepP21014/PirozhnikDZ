#pragma once
#include <iostream>
#include <list>


using namespace std;

template <class Tkey, class Tvalue>
class UnorderedMap
{
private:
	struct Pair
	{
		Pair(Tkey k, Tvalue v) : m_key(k), m_value(v) { };
		Tkey m_key;
		Tvalue m_value;
	};
	int m_element_count;
public:
	list<Pair> m_pairs;
public:
	UnorderedMap() : m_element_count(0) {}
	~UnorderedMap() {}

	Tvalue &operator[](const Tkey &key)
	{
		// look for index in list
		for (auto i = m_pairs.begin(); i != m_pairs.end(); i++)
		{
			if (i->m_key == key)
				return i->m_value;

		}
		// otherwise add anitem and return a reference to value
		m_element_count++;
		m_pairs.push_back(Pair(key, Tvalue()));
		return m_pairs.back().m_value;
	}

	int Count()
	{
		return m_element_count;
	}

	void Show()
	{
		for (auto i = m_pairs.begin(); i != m_pairs.end(); i++)
		{
			cout << i->m_key << " -> " << i->m_value << endl;
		}
		/*cout << "once again\n";
		// for each loop
		for (auto Pair : m_pairs) {
		cout << Pair.m_key << " -> " << Pair.m_value << endl;
		}
		*/
	}
};
