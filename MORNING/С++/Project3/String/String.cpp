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

int String::Plus(const char *source){
	length += strlen(source);
	s = (char*)realloc(s, length + 1);
	if (s == 0){
		length -= strlen(source);
		return 0;
	}
	strcat(s, source);
	return 1;
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

void String::operator= (const String& source){
	free(s);
	length = source.length;
	s = (char*)malloc(sizeof(char)*(length + 1));
	strcpy(s, source.s);
}

String::String(char c, size_t n){
	s = (char*)malloc(n * sizeof(char) + 1);
	memset(s, c, n);
	s[n] = 0;
	length = n;
}

//явно указываем способ создания копии для функций
String::String(const String &orig){
	s = (char*)malloc(strlen(orig.s) + 1);
	strcpy(s, orig.s);
}

String::~String(){
	free(s);
}

void PrintStr(String str){
	str.PrintStr();
}





String String::Pluss(const String str) const 
{
	String new_string(s);
	new_string.Plus(str.s);
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
			new_string.s[i] = s[length-n+i];
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