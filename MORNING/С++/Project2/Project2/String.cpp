#define _CRT_SECURE_NO_WARNINGS
#include "String.h"
#include <cstdlib>
#include <cstring>
#include <cstdio>

String::String()
{
	printf("defoult constr call\n");
	s = (char*)malloc(1);
	s[0] = 0;
}

String::String(const char *p)
{
	printf("char* constr call\n");
	s = (char*)malloc(strlen(p) + 1);
	strcpy(s, p);
}

String::String(char c, size_t n)
{
	printf("repeat constr call\n");
	s = (char*)malloc((n+1)*sizeof(char));
	memset(s, c, n);
	s[n] = 0;
}

String::String(const String& orig)
{
	printf("copy constr call\n");
	s = (char*)malloc(strlen(orig.s) + 1);
	strcpy(s, orig.s);
}

void String::print() {
	printf("%s\n", s);
}

String::~String()
{
	printf("destruconstr call\n");
	free(s);
}

void print(String str)
{
	printf("insined print\n");
	str.print();
}

const char* String::find(String& substring)
{
	return strstr(s, substring.s);
}

const char* String::c_str()
{
	return s; 
}

String& String::plus(String str)
{
	s = (char*)realloc(s, (strlen(s) + strlen(str.s) + 1) * sizeof(char));
	strcat(s, str.s);
	return *this; // вернуть самого себя
}