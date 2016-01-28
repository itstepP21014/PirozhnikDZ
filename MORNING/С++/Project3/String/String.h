#pragma once


class String
{
private:
	char *s;
	int length;
public:
	void PrintStr() const; // метод кот печатает строку
	const char *Find(const char *substr) const;
	int Plus(const char *source);
	const char *cstr() const //возвращает строку в неизменяемом виде
	{
		return s;
	}
	// перегрузка оператора присваивания
	void operator = (const String& source); // передаем по константной ссылке потому что обещаю не изменять

	String Pluss(const String str) const;
	void UpperCase();
	String First(const int n) const;
	String Last(const int n) const;
	String GetSubstring(const int n, const int len) const;

	//ctor
	String();
	String(const char *p);
	String(char c, size_t n);
	String(const String &orig); //конструктор копирования
	//dtor
	~String();
};

void PrintStr(String str);

inline int sqr(int x){
		return x*x;
}
