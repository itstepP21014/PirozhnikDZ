#pragma once

class String
{
private:
	char *s;
	int length;
public:
	// методы 
	void PrintStr() const; // метод кот печатает строку
	const char *Find(const char *substr) const; // метод кот находит подстроку в строке
	String& String::operator+= (const String& what); // метод кот присоединяет строку к концу другой строки (вместо String Pluss(const String str) const;)
	const char *cstr() const { //возвращает строку в неизменяемом виде
			return s;
	}
	// перегрузка оператора присваивания
	void operator= (const String& source); // оператор присваивания (передаем по константной ссылке потому что обещаю не изменять)

	String String::Plus(const String str) const;
	void UpperCase();
	String First(const int n) const;
	String Last(const int n) const;
	String GetSubstring(const int n, const int len) const;

	//String String::operator+ (const String what);


	//ctor
	String();
	String(const char *p);
	String(char c, size_t n);
	String(const String &orig); //конструктор копирования
	//dtor
	~String();
};

void PrintStr(String str); // функция 


inline int sqr(int x){ // 
	return x*x;
}


//String operator+ (const String& a, const String& b);