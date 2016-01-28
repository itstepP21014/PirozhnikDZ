using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator
{

    using System.Collections;

    public class PersonList: IEnumerable
    {
        public Person[] _people;
        public PersonList(Person[] list)
        {
            _people = list;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumrator();
        }

        public PeopleEnum GetEnumrator() // .begin()
        {
            return new PeopleEnum(_people);
        }

    }


    public class Person
    {
        public string name = "AAAA";
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (System.IndexOutOfRangeException)
                {
                    throw new System.InvalidOperationException();
                }
            }
        }
    }


    class Program
    {



        static void Main(string[] args)
        {
            PersonList p = new PersonList ( new Person[] { new Person(), new Person()});
            PeopleEnum en = p.GetEnumrator();
            while (en.MoveNext())
            {
                Console.WriteLine(en.Current.name);
            }

            foreach (Person x in p)
            {
                Console.WriteLine( x.name );
            }
                 

        }
    }
}
