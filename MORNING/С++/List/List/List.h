#pragma once

class List {
public:
	struct SingleListItem {
		int data;
		SingleListItem *next;

	};
private:
	// ��������� �� ������ ������� ������
	SingleListItem *first;
	// ������ ������
	size_t size;

	static int junk;

public:
	// size � ��� ���������, �� ���� ������� � ���� ������ ��� ������
	size_t getSize(){
		return size;
	};

	List& push_front(int data);
	List& pop_front();
	List& push_back(int data);
	List& pop_back();
	int& operator[] (size_t index);

	List()
	// ������ ������������� ������������ (���� ������ ��������� ���������������� ���������)
	: first(nullptr), size(0)
	{
		//first = nullptr;
		//size = 0;
	};

	~List();
};