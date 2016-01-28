#pragma once

class List {
public:
	struct SingleListItem {
		int data;
		SingleListItem *next;

	};
private:
	// указатель на первый элемент списка
	SingleListItem *first;
	// длинна списка
	size_t size;

	static int junk;

public:
	// size у нас приватный, но надо сделать к нему доступ для чтения
	size_t getSize(){
		return size;
	};

	List& push_front(int data);
	List& pop_front();
	List& push_back(int data);
	List& pop_back();
	int& operator[] (size_t index);

	List()
	// список инициализации конструктора (этот способ позволяет инициализировать константы)
	: first(nullptr), size(0)
	{
		//first = nullptr;
		//size = 0;
	};

	~List();
};