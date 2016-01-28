#include "Double_List.h"
#include <iostream>

using namespace std;

int& Double_List::operator[] (size_t index) {
	if (index > size - 1) throw 1;
	Node *temp = first;
	for (size_t i = 0; i < index; ++i){
		temp = temp->next;
	}
	return temp->data;
}

Double_List& Double_List::push_front(int data) {
	Node *node = nullptr;
	node = new Node;
	if (node == nullptr) throw 2;
	node->data = data;
	node->next = first;
	node->prev = nullptr;
	first = node;
	++size;
	return *this;
}

Double_List& Double_List::pop_front() {

	if (first == nullptr) throw 3;
	Node *temp = first;
	first = first->next;
	delete temp;
	--size;
	return *this;
}

/*


List& List::push_back(int data) {
	SingleListItem *node = nullptr;
	node = new SingleListItem;
	node->data = data;
	node->next = nullptr;

	SingleListItem *temp = first;
	while (temp->next == nullptr){
		temp = temp->next;
	}
	temp->next = node;
	++size;
	return *this;
}

List& List::pop_back() {
	if (first != nullptr){
		SingleListItem *temp = first;
		while (temp->next == nullptr){
			temp = temp->next;
		}

		delete temp;
		--size;
	}
	return *this;
}



*/

Double_List::~Double_List() {
	while (size > 0){
		pop_front();
	}
}