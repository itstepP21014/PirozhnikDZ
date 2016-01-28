#pragma once
#include <string>

using namespace std;

template <class Tkey, class Tvalue>
class tree
{
private:
	struct Node {
		// ����������� �� ��������� (��� ���������)
		Node(const Tkey &key_, const Tvalue value_ = 0)
		: left(nullptr), right(nullptr), key(key_), value(value_) {};
		Node *left;
		Node *right;
		Tvalue value;
		const Tkey key;
	};
	Node *root;

public:
	// ����������� ��� ������
	tree() : root(nullptr) {};
	~tree() {
		DestroyTree(root);
	};

	float& operator[] (const string &key) {
		Node *current = root;
		Node **pointer = &root; // pointer - ��� ��������� �� ����� ������, ��� ����� current
		while (current != nullptr) {
			if (key < current->key) { // ���� �����
				pointer = &(current->left);
				current = current->left;
			}
			else if (key == current->key) { // �����
				return current->value;
			}
			else { // ���� ������
				pointer = &(current->right);
				current = current->right;
			}	
		} // end of while
		// ���� ������ �� �������
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