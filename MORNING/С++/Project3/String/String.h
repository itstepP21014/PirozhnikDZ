#pragma once


class String
{
private:
	char *s;
	int length;
public:
	void PrintStr() const; // ����� ��� �������� ������
	const char *Find(const char *substr) const;
	int Plus(const char *source);
	const char *cstr() const //���������� ������ � ������������ ����
	{
		return s;
	}
	// ���������� ��������� ������������
	void operator = (const String& source); // �������� �� ����������� ������ ������ ��� ������ �� ��������

	String Pluss(const String str) const;
	void UpperCase();
	String First(const int n) const;
	String Last(const int n) const;
	String GetSubstring(const int n, const int len) const;

	//ctor
	String();
	String(const char *p);
	String(char c, size_t n);
	String(const String &orig); //����������� �����������
	//dtor
	~String();
};

void PrintStr(String str);

inline int sqr(int x){
		return x*x;
}
