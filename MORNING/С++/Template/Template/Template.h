#pragma once

template <class T>
class List {
public:
	struct Node {
		T data;
		Node *next;

	};
private:
	Node *first;
	size_t size;
public:
	size_t getSize(){
		return size;
	};

	List& push_front(T data){
		Node *node = nullptr;
		node = new Node;
		node->data = data;
		node->next = first;
		first = node;
		++size;
		return *this;
	}

	List& pop_front() {
		if (first != nullptr){
			Node *temp = first;
			first = first->next;
			delete temp;
			--size;
		}
		return *this;
	}

	List& push_back(T data) {
		Node *node = nullptr;
		node = new Node;
		node->data = data;
		node->next = first;
		first = node;
		++size;
		return *this;
	}

	List& pop_back() {
		if (first != nullptr){
			Node *temp = first;
			while (temp->next == nullptr){
				temp = temp->next;
			}

			delete temp;
			--size;
		}
		return *this;
	}

	T& operator[] (size_t index){
		Node *temp = first;
		for (size_t i = 0; i < index; ++i){
			temp = temp->next;
		}
		return temp->data;
	}


	List() : first(nullptr), size(0) {
	};

	~List() {
		while (size > 0){
			pop_front();
		}
	}
};

template <class T>
class Map {

};