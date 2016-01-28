using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{

    abstract class Animal {
        public readonly string name; // = const, но меняется только в конструкторе

        protected Animal(string name) {
            this.name = name;
        }

        abstract public void voice();

    }

    interface IFlyer {
        void fly();
        //string Name {get; set;}
        //int this [int index] {get; set;}
    }


    class Crocodile : Animal {
        public Crocodile() : // все крокодилы Гены
            base("Gena") {

        }

        public Crocodile(string name) : // даем крокодилу имя сами
            base(name) {

        }

        override public void voice() {
            Console.WriteLine("Crocodile " + name + " says GAU.");
        }

    }

    class Bird : Animal, IFlyer {
        public Bird() : // все крокодилы Гены
            base("Chika") {

        }

        public Bird(string name) :
            base(name) {

        }

        override public void voice() {
            Console.WriteLine("Bird " + name + " says CHIRIK.");
        }

        public void fly()
        {
            Console.WriteLine("Bird " + name + " flies.");
        }

    }


    class Program {
        static void Main(string[] args) {

            var zoo = new Animal[2] {new Crocodile(), new Bird("Chacha")};

            foreach (var a in zoo) {
                a.voice();

                try{
                    IFlyer f = (IFlyer)a;
                    f.fly();
                }
                catch (InvalidCastException e) {
                    // исключение
                }

            }

            Console.ReadLine();
        }
    }
}
