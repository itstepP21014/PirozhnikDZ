#pragma once
#include <string>
#include "AssociativeArray.h"
#include <vector>

template <class Tkey, class Tvalue>
class Hash
{
private:
	int m_size;
	int m_element_count;
	vector<UnorderedMap<Tkey, Tvalue> > m_arr_of_map;
public:
	Hash(size_t size) : m_size(3 * size), m_element_count(0), m_arr_of_map(m_size) {}
	~Hash()
	{
		//delete[] m_arr_of_map;
	}

	Hash &Initialize(int size);
	Tvalue &operator[](Tkey key);
	void Show();
	Hash &Delete(Tkey key);
	Tkey &SearchValue(Tvalue value);
	Tkey &SearchValue(Tkey key, Tvalue value);
	int GetSize()
	{
		return m_size;
	}
	int GetCount()
	{
		return m_element_count;
	}
	vector<UnorderedMap<Tkey, Tvalue> > &GetArr()
	{
		return m_arr_of_map;
	}
};


template <class Tkey, class Tvalue>
Hash<Tkey, Tvalue> &Hash<Tkey, Tvalue>::Initialize(int size)
{
	throw "not implemented";
	//m_size = 3 * size;
	//m_arr_of_map = new UnorderedMap<Tkey, Tvalue>[m_size]();
	return *this;
}


template <class Tkey, class Tvalue>
Tvalue &Hash<Tkey, Tvalue>::operator[](Tkey key)
{
	int dig = Digest(key) % m_size;
	int qqq = m_arr_of_map[dig].Count();
	Tvalue &temp = m_arr_of_map[dig][key];
	m_element_count += (m_arr_of_map[dig].Count() - qqq);
	return temp;
}


template <class Tkey, class Tvalue>
void Hash<Tkey, Tvalue>::Show()
{
	for (int i = 0; i < m_size; i++)
		m_arr_of_map[i].Show();
}


template <class Tkey, class Tvalue>
Hash<Tkey, Tvalue> & Hash<Tkey, Tvalue>::Delete(Tkey key)
{
	int dig = Digest(key);
	UnorderedMap<Tkey, Tvalue> *temp = &(m_arr_of_map[dig % m_size]);
	for (auto it = temp->m_pairs.begin(); it != temp->m_pairs.end(); it++)
	{
		if (it->m_key == key)
		{
			temp->m_pairs.erase(it);
			--m_element_count;
			break;
		}
	}
	return *this;
}


template <class Tkey, class Tvalue>
Tkey &Hash<Tkey, Tvalue>::SearchValue(Tvalue value)
{
	for (int i = 0; i < m_size; i++)
	{
		UnorderedMap<Tkey, Tvalue> &temp = m_arr_of_map[i];

		for (auto it = temp.m_pairs.begin(); it != temp.m_pairs.end(); it++)
		{
			//cout << "looking for " << value << " found i=" << i << " val " << it->m_value << endl;
			if (it->m_value == value)
				return it->m_key;
		}
	}
	throw 1;
}


template <class Tkey, class Tvalue>
Tkey &Hash<Tkey, Tvalue>::SearchValue(Tkey key, Tvalue value)
{
	// ïîèñê ïîçèöèè, îò êîòîðîé íåîáõîäèìî íà÷àòü ïîèñê
	int i = Digest(key) % m_size;
	UnorderedMap<Tkey, Tvalue> *temp = &(m_arr_of_map[i]);
	auto it = temp->m_pairs.begin;
	while (it->m_key != key)
		it++;

	// ïîèñê
	for (i++; i < m_size; i++)
	{

		for (it++; it != temp->m_pairs.end(); it++)
		{
			if (it->m_value == value)
				return it->m_key;
		}
	}
	throw 1;

}


template <class Tkey>
int Digest(Tkey key);

int Digest(int key);
int Digest(std::string key); // implicit instatiation