#include <stdio.h>
#include <stdlib.h>

/*

    emum sex {male, female};
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

void setX(int value)
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
