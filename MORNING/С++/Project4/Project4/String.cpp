#define _CRT_SECURE_NO_WARNINGS

#include "String.h"
#include <cstdlib>
#include <cstring>
#include <iostream>

void String::PrintStr() const{
	std::cout << s << std::endl;
}

const char *String::Find(const char *substr) const{
	return strstr(s, substr);
}

void String::operator= (const String& source){
	free(s);
	length = source.length;
	s = (char*)malloc(sizeof(char)*(length + 1));
	strcpy(s, source.s);
}

void PrintStr(String str){
	str.PrintStr();
}

String& String::operator+= (const String& what){
	length += strlen(what.s);
	s = (char*)realloc(s, length + 1);
	if (s == 0){
		length -= strlen(what.s);
	}
	strcat(s, what.s);
	return *this;
}


String::String(){
	s = (char*)malloc(sizeof(char));
	s[0] = 0; // *s = '\0'
	length = 0;
}

String::String(const char *p){
	length = strlen(p);
	s = (char*)malloc(length * sizeof(char)+1);
	strcpy(s, p);
}

String::String(char c, size_t n){
	s = (char*)malloc(n * sizeof(char)+1);
	memset(s, c, n);
	s[n] = 0;
	length = n;
}

//���� ��������� ������ �������� ����� ��� �������
String::String(const String &orig){
	s = (char*)malloc(strlen(orig.s) + 1);
	strcpy(s, orig.s);
}

String::~String(){
	free(s);
}




String String::Plus(const String str) const
{
	String new_string(s);
	new_string += str.s;
	return new_string;
}

void String::UpperCase(){
	for (int i = 0; i < strlen(s); ++i){
		s[i] = toupper(s[i]);
	}
}

String String::First(const int n) const{
	if (n > strlen(s)){
		printf("Error!\n");
		exit(1);
	}
	else{
		String new_string(' ', n);
		for (int i = 0; i < n; ++i){
			new_string.s[i] = s[i];
		}
		new_string.s[n] = 0;
		return new_string;
	}
}

String String::Last(const int n) const{
	if (n > strlen(s)){
		printf("Error!\n");
		exit(1);
	}
	else{
		String new_string(' ', n);
		int len = length;
		for (int i = 0; i < n; ++i){
			new_string.s[i] = s[length - n + i];
		}
		new_string.s[n] = 0;
		return new_string;
	}
}

String String::GetSubstring(const int n, const int len) const{
	if ((n + len) > strlen(s)){
		printf("Error!\n");
		exit(1);
	}
	else{
		String new_string(' ', len);
		for (int i = 0; i < len; ++i){
			new_string.s[i] = s[(n - 1) + i];
		}
		new_string.s[len] = 0;
		return new_string;
	}
}
/*
String String::operator+ (const String what){ // ����� add
	String res(*this);
	res += what;
	return res;
}

String operator+ (const String& a, const String& b){ // ������� add 
	String res(a);
	res += b;
	return res;
}
*/