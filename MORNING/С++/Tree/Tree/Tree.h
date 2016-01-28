#pragma once
#include <string>

using namespace std;

template <class Tkey, class Tvalue>
class tree
{
private:
	struct Node {
		// конструктор по умолчанию (для структуры)
		Node(const Tkey &key_, const Tvalue value_ = 0)
		: left(nullptr), right(nullptr), key(key_), value(value_) {};
		Node *left;
		Node *right;
		Tvalue value;
		const Tkey key;
	};
	Node *root;

public:
	// конструктор для класса
	tree() : root(nullptr) {};
	~tree() {
		DestroyTree(root);
	};

	float& operator[] (const string &key) {
		Node *current = root;
		Node **pointer = &root; // pointer - это указатель на место памяти, где лежит current
		while (current != nullptr) {
			if (key < current->key) { // идем влево
				pointer = &(current->left);
				current = current->left;
			}
			else if (key == current->key) { // нашли
				return current->value;
			}
			else { // идем вправо
				pointer = &(current->right);
				current = current->right;
			}	
		} // end of while
		// если ничего не найдено
		*pointer = new Node(key);
		return (*pointer)->value;
	}

	void DestroyTree(Node *current) {
		if(current) {
		  DestroyTree(current->left);
		  DestroyTree(current->right);
		  delete current;
		}
	}

	void PrintTree() {
		PrintTree(root);
	}

private:
		void PrintTree(Node *current) {
			if (current) {
				PrintTree(current->left);
				cout << current->key << " => "<< current->value << endl;
				PrintTree(current->right);
			}
		}

};