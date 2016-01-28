#include "Hash.h"

int Digest(std::string key)
{
	int code = 0;
	for (auto i = 0; i < key.size(); i++)
		code += key[i];
	return code;
}

int Digest(int key)
{
	return key;
}