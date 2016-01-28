#include "Iterator.h"
#include <new>



// standart
List &List::PushFront(void *element)
{
	Node *new_element = new Node;
	new_element->data = new char[element_size];
	new_element->data = element;

	// connect
	new_element->previous = nullptr;
	new_element->next = begin;
	if (begin != nullptr)
		begin->previous = new_element; //ïðèâÿçûâàåì ïåðâûé ýëåìåíò ê íîâîìó

	begin = new_element; //ïåðåìåøàåì begin íà íà÷àëî
	if (end == nullptr)
		end = new_element; //ñòàâèì êîíåö íà íîâûé ýëåìåíò
	++element_count;
	return *this;
}
List &List::PopFront()
{
	if (element_count == 0)
		throw 0;
	Node *temp = begin;
	begin = temp->next;
	//delete temp->data;????????
	delete temp;
	if (element_count == 1)
		end = nullptr;
	else
		begin->previous = nullptr;
	--element_count;
	return *this;
}
List &List::PushEnd(void *element)
{
	Node *new_element = new Node;
	new_element->data = new char[element_size];
	new_element->data = element;
	new_element->next = nullptr;
	new_element->previous = end;
	end->next = new_element;
	end = new_element;
	if (element_count == 0)
		begin = new_element;
	++element_count;
	return *this;
}
List &List::PopEnd()
{
	if (element_count == 0)
		throw 0;
	Node *temp = end;
	end->next = nullptr;
	if (element_count = 1)
	{
		begin = nullptr;
		end = nullptr;
	}
	else
		end = end->previous;
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
		temp = end;
		for (int i = 0; i < index; i++)
			temp = temp->previous;
	}
	else
	{
		temp = begin;
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
	Node *temp = source.begin;
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
	Node *temp = this->begin, *temp_previous;
	this->begin = this->end;
	this->end = temp;
	for (int i = 0; i < element_count; i++, temp = temp->next)
	{
		temp_previous = this->begin->previous;
		this->begin->previous = this->begin->next;
		this->begin->next = temp_previous;
	}
	return *this;
}


// ctor
List::List(const List &orig)
{
	element_size = orig.element_size;
	element_count = orig.element_count;
	Node *temp = begin;
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
