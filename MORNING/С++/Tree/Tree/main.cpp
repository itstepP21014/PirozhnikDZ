#include "Tree.h"
#include <iostream>
#include <string>

int main()
{
		tree<string, float> t;
		t["mama"] = 32.0f;
		t["papa"] = 11.0f;
		t["baba"] = 4.0f;

		t.PrintTree();
		getc(stdin);
		return 0;
}