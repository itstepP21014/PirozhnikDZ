#include <string>
#include "Unordered_Map.h"
#include "Hash_Map.h"

#include <iostream>

using namespace std;


int main() {
	/*
	Unordered_Map<string, float> people;
	people["Anna"] = 1.7f;
	people["Julia"] = 1.8f;
	people["Hovard"] = 2.0f;

	people.show();
	*/

	Hash_Map<string, string> pats(3);
	pats["cat"] = "Tom";
	pats["dog"] = "Chappy";
	pats["parrot"] = "Kesha";

	pats.show();

	string s = pats.find("dog");
	cout << s << endl;





	getc(stdin);
		
	return 0;
}