#include "List.h"
#include <iostream>

using namespace std;

// резервируем место под статическое поле
int List::junk;

List& List::push_front(int data) {
	SingleListItem *node = nullptr;
	node = new SingleListItem;
	node->data = data;
	node->next = first;
	first = node;
	++size;
	return *this;
}

List& List::pop_front() {
	if (first != nullptr){
		SingleListItem *temp = first;
		first = first->next;
		delete temp;
		--size;
	}
	return *this;
}

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

int& List::operator[] (size_t index) {
	if (index > size - 1){
		// static int junk; // static вместо того чтобы делать ее глобальной
		return junk;
	}
	SingleListItem *temp = first;
	for (size_t i = 0; i < index; ++i){
		temp = temp->next;
	}
	return temp->data;
}

List::~List() {
	while (size > 0){
		pop_front();
	}
}