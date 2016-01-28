#pragma once

class String
{
private:
	char *s;
public:
	String();  // ����������� �� ���������
	String(const char *p);
	String(char c, size_t n);

	String(const String& p); // ����������� �����������

	~String();

	void print();

	const char* find(String& substring); // ����� ���������
	const char* c_str(); // 
	String& plus(String str); // �������� ����� 

};

void print(String str);