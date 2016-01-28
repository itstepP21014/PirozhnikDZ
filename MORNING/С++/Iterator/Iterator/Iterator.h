#pragma once
#include <iostream>
#include <exception>
#include <stdexcept>

using namespace std;

typedef void* INT;



class List
{
private:
	struct Node
	{
		void *data;
		Node *next;
		Node *previous;
	};
public:

	class iterator {
	private:
		Node* current;
	public:
		iterator(Node* arg) : current(arg) {};
		iterator() : iterator(nullptr) {};
		INT & operator*() {
			if (current == nullptr) {
				throw invalid_argument(
					"In List::iterator::operator*() : invalid iterator");
			}
			return current->data;
		}
		iterator& operator++() {
			if (current == nullptr) {
				throw invalid_argument(
					"In List::iterator::operator*() : invalid iterator");
			}
			current = current->next;
			return (*this);
		}

		bool operator==(const iterator &i) const{
			return current == i.current;
		}

		bool operator!=(const iterator &i) const{
			return current != i.current;
		}
	};  // end of List::iterator

	iterator begin() {
		return iterator(Begin);
	}
	iterator end() {
		return iterator(nullptr);
	}

	Node *Begin;
	Node *End;
	int element_count;
	int element_size;

public:

	size_t ElementCount()
	{
		return element_count;
	}

	// standart
	List &PushFront(void *element);
	List &PopFront();

	List &PushEnd(void *element);
	List &PopEnd();

	Node *operator[](int index);
	List &operator=(const List &source);

	List &Delete(int index);
	List &Reverse();

	// ctor
	List(int size_of_element) : element_size(size_of_element), element_count(0), Begin(nullptr), End(nullptr) {};
	List(const List &orig);

	iterator find(void* value) {
		Node* current;
		current = Begin;
		while (current != nullptr) {
			if (current->data == value) {
				return iterator(current);
			}
			current = current->next;
		}
		return iterator(current);
	}

	// dtor
	~List();


};

#include <new>



// standart
List &List::PushFront(void *element)
{
	Node *new_element = new Node;
	new_element->data = new char[element_size];
	new_element->data = element;

	// connect
	new_element->previous = nullptr;
	new_element->next = Begin;
	if (Begin != nullptr)
		Begin->previous = new_element; //ïðèâÿçûâàåì ïåðâûé ýëåìåíò ê íîâîìó

	Begin = new_element; //ïåðåìåøàåì Begin íà íà÷àëî
	if (End == nullptr)
		End = new_element; //ñòàâèì êîíåö íà íîâûé ýëåìåíò
	++element_count;
	return *this;
}
List &List::PopFront()
{
	if (element_count == 0)
		throw 0;
	Node *temp = Begin;
	Begin = temp->next;
	//delete temp->data;????????
	delete temp;
	if (element_count == 1)
		End = nullptr;
	else
		Begin->previous = nullptr;
	--element_count;
	return *this;
}
List &List::PushEnd(void *element)
{
	Node *new_element = new Node;
	new_element->data = new char[element_size];
	new_element->data = element;
	new_element->next = nullptr;
	new_element->previous = End;
	End->next = new_element;
	End = new_element;
	if (element_count == 0)
		Begin = new_element;
	++element_count;
	return *this;
}
List &List::PopEnd()
{
	if (element_count == 0)
		throw 0;
	Node *temp = End;
	End->next = nullptr;
	if (element_count = 1)
	{
		Begin = nullptr;
		End = nullptr;
	}
	else
		End = End->previous;
	//delete temp->data;???????
	delete temp;
	--element_count;
	return *this;
}

List::Node *List::operator[](int index)
{
	if (index >= element_count)
		throw 1;
	Node *temp;
	if (index <= element_count / 2)
	{
		temp = End;
		for (int i = 0; i < index; i++)
			temp = temp->previous;
	}
	else
	{
		temp = Begin;
		for (int i = element_count - 1; i > index; i--)
			temp = temp->next;
	}
	return temp;

}
List &List::operator=(const List &source)
{
	while (element_count--)
		PopFront();
	element_count = source.element_count;
	element_size = source.element_size;
	Node *temp = source.Begin;
	for (int i = 0; i < element_count; i++, temp = temp->next)
	{
		PushEnd(temp->data);
	}
	return *this;
}

List &List::Delete(int index)
{
	if (index >= element_count || index < 0)
		throw 1;
	if (index == 0)
		PopFront();
	else if (index == element_count - 1)
		PopEnd();
	else
	{
		Node *temp = this->operator[](index);
		Node *help_next = temp->next;
		(temp->next)->previous = temp->previous;
		(temp->previous)->next = help_next;
		delete temp;
	}
	return *this;
}
List &List::Reverse()
{
	Node *temp = this->Begin, *temp_previous;
	this->Begin = this->End;
	this->End = temp;
	for (int i = 0; i < element_count; i++, temp = temp->next)
	{
		temp_previous = this->Begin->previous;
		this->Begin->previous = this->Begin->next;
		this->Begin->next = temp_previous;
	}
	return *this;
}


// ctor
List::List(const List &orig)
{
	element_size = orig.element_size;
	element_count = orig.element_count;
	Node *temp = Begin;
	for (int i = 0; i < element_count; i++, temp = temp->next)
	{
		PushEnd(temp->data);
	}
}

// dtor
List::~List()
{
	while (element_count)
		PopFront();
}


#include <iostream>
#include <conio.h>
#include <new>



using namespace std;
int main()
{
	List a_int(sizeof(int));

	for (int i = 0; i < 7; i++)
		a_int.PushFront((INT)i);

	List::iterator p = a_int.find((INT)4);

	List::iterator q;

	for (; p != a_int.end(); ++p) {
		*p = (INT)8;
		cout << ((int)*p) << endl;
	}

	return 0;

	int size_a = a_int.ElementCount();
	cout << "element count in a_int = " << size_a << endl;
	a_int[6]->data = (void*)20;
	for (int i = 0; i < size_a; i++)
		cout << (int)a_int[i]->data << ' ';

	_getch();
	return 0;
}