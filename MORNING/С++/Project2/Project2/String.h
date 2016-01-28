#pragma once

class String
{
private:
	char *s;
public:
	String();  // конструктор по умолчанию
	String(const char *p);
	String(char c, size_t n);

	String(const String& p); // конструктор копирования

	~String();

	void print();

	const char* find(String& substring); // поиск подстроки
	const char* c_str(); // 
	String& plus(String str); // сложение строк 

};

void print(String str);