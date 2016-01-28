#include <iostream>
#include "Test.h"
using namespace std;

int main() {
	string username;

	if (username == "") {
		cout << "Enter your name:";
		cin >> username;
	}

	Test T(username);
	while (!T.finished())	{
		T.ask();
	}

	T.show_result();

	return 0;
}
