#include <iostream>

using namespace std;


/*
    enum Sex {male, female};
    class Persona
    {
    private:
        char name[128];
        int age;
        Sex sex;
    public:
        char *whatIsYourName() const;
        int howOldAreYou() const;
        void celebrateBirthday();
        Persona(char *name, int age, Sex sex); // konstruktor
    };

int main()
{
    Persona vasia("Vasia Ivanov", 22, male);
    cout << vasia.whatIsYourName();
    cout << vasia.howOldAreYou();
    // vasia.age = 44           - ne kompilitsya, zdes' menyat' my nichego ne mozhem
    vasia.celebrateBirthday(); // a zdes' my mozhem izmenit' vozrast
    return 0;
}
*/








/*
class A
{
public:
    int getX() const;
    void setX(int value);
private:
    int x;
};

int A :: getX() const
{
    return x;
}

void A :: setX(int value)
{
    x = value;
}

int main()
{
    A a;
    a.setX(5);
    cout << a.getX();
    return 0;
}
*/






/*
class A
{
public:
    int &x();
private:
    int x_;
};

int &A :: x()
{
    return x_;
}

int main()
{
A a;
a.x() = 5;
cout << a.x();
    return 0;
}
*/





/*
class A
{
public:
    int x;
};

int main()
{
    A a;
    a.x = 5;
    cout << a.x;
    return 0;
}
*/
