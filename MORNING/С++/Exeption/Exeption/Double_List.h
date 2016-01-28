#pragma once

class Double_List {
public:
	struct Node {
		int data;
		Node *next;
		Node *prev;

	};
private:
	Node *first;
	Node *last;
	size_t size;

	static int junk;

public:
	size_t getSize(){
		return size;
	};

	Double_List& push_front(int data);
	Double_List& pop_front();
	/*
	Double_List& push_back(int data);
	Double_List& pop_back();
	*/
	int& operator[] (size_t index);


	Double_List()
		: first(nullptr), last(nullptr), size(0) {
	};

	~Double_List();
};