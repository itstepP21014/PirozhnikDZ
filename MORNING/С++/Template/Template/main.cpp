#include "Template.h"
#include <iostream>

using namespace std;

int main() {
	/*
	List<int> l;
	l.push_front(1234).push_front(12).push_front(56).push_front(222);
	for (size_t i = 0; i < l.getSize(); ++i){
		cout << l[i] << endl;
	}
	*/

	/*
	List<int*> a;
	const size_t size = 3;
	int arr[size] = { 3, 5, 7 };
	int mas[size] = { 2, 6, 8 };
	a.push_front(arr).push_front(mas);
	for (size_t i = 0; i < a.getSize(); ++i){
		for (size_t j = 0; j < size; ++j) {
			cout << a[i][j];
		}
		cout << endl;
	}
	*/

	/*
	List<char*> s;
	s.push_front("hello").push_front("good").push_front("bye");
	for (size_t i = 0; i < s.getSize(); ++i){
		cout << s[i] << endl;
	}
	*/
	
	Map<string, string> arr;
	arr["cat"] = "Tom";
	arr["dog"] = "Chappy";
	arr["parrot"] = "Ricky";
	cout << arr["cat"] << endl;
	cout << arr["dog"] << endl;
	cout << arr["parrot"] << endl;
	
	getc(stdin);
	return 0;
}