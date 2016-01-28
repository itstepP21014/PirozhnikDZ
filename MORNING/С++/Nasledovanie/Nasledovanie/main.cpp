#include <string>
#include <iostream>

using namespace std;

class Animal {
public:
	string name;
	Animal (string name_) : name(name_){};
	~Animal() {};
	virtual void voice() {};
};

// интерфейс
class Flyer {
public:
	Flyer() {};
	~Flyer() {};
	virtual void fly() {}; // чисто абстрактный метод, а слеловательно и класс в целом
};

class Mammal : public Animal {
public:
	Mammal(string name_) : Animal(name_) {};
	~Mammal() {};
};

class Bat : public Mammal, public Flyer {
public:
	Bat() : Mammal("dfghjk") {};
	Bat(string name) : Mammal(name) {};
	~Bat() {};
	virtual void fly() {
		cout << "Bat's flying" << endl;
	};
	virtual void voice() {
		cout << "Bat's saying 'pi-pi!'";
	};
};

class Lupus : public Mammal {
public:
	Lupus() : Mammal("hfgvjh") {};
	Lupus(string name) : Mammal(name) {};
	~Lupus() {};
	virtual void voice() {
		cout << "Lupus's saying 'Grrrrr!'";
	};
};

class Bird : public Animal, public Flyer {
public:
	Bird() : Animal("hfgvjh") {};
	Bird(string name) : Animal(name) {};
	~Bird() {};
	virtual void fly() {
		cout << "Bird's flying" << endl;
	};
	virtual void voice() {
		cout << "Bird's saying 'Tiu-Tiu!'";
	};
};

class Helicopter : public Flyer {
public:
	Helicopter() {};
	~Helicopter() {};
	virtual void fly() {
		cout << "Helicopter's flying" << endl;
	};
};


int main() {
	Lupus yo("jghjh");
	Bat man;
	Helicopter john;

	return 0;
}
