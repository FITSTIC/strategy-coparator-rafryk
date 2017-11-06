using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var nipote = new Person(6, "Luca", "Cippo");
            var nonno = new Person(45, "Aristide", "Merotti");
            var mario = new Person(35, "Mario", "Perotti");
            var gino = new Person(33, "Gino", "Negro");
            var lorenzo = new Person(1, "Lorenzo", "Verratti");
            var marcello = new Person(21, "Lorenzo", "Ciccio");
            var davide = new Person(100, "Davide", "Basso");
          

            Person[] arrayPerson = {nipote,nonno,mario,gino,lorenzo,marcello,davide};

            var comparator = new PersonComparator();

            // Età Comparator
            Person[] listAge = comparator.Compare(arrayPerson, new AgeComparator());
            //Console.WriteLine("La persona più giovane è :"+listAge[0].name);//Luca Cippo
            Console.WriteLine("Classifica ordinata per l'età:");
            //Console.WriteLine(listAge.Length);
            for (int i = 0; i < listAge.Length; i++) {
              Console.WriteLine(listAge[i].ToString());
            }
            // Nome Comparator
            Person[] listFirstName = comparator.Compare(arrayPerson, new NameComparator());
            //Console.WriteLine("La prima persona in ordine di nome è :"+listFirstName[0].firstName);//Aristide Merotti
            Console.WriteLine("Classifica ordinata per il nome");
            for (int i = 0; i < listFirstName.Length; i++) {
              Console.WriteLine(listFirstName[i].ToString());
            }
            Console.ReadLine();
        }
    }

    /*
    * Comparatore della Età
    */
    class AgeComparator : IPersonStrategy
    {
        public Person[] Sort(Person[] arrayPerson)
        {
            Person[] result = new Person[arrayPerson.Length];
            //Bubble Sort
            int i;
            int j;
            Person temp;

            for (i = (arrayPerson.Length - 1); i >= 0; i--)
            {
              for (j = 1; j <= i; j++)
              {
                if (arrayPerson[j - 1].age > arrayPerson[j].age)
                {
                  temp = arrayPerson[j - 1];
                  arrayPerson[j - 1] = arrayPerson[j];
                  arrayPerson[j] = temp;
                }
              }
            }
            result = arrayPerson;
            return result;
        }
    }
    /*
    * Comparatore del Nome e Cognome
    */
    class NameComparator : IPersonStrategy
    {
        public Person[] Sort(Person[] arrayPerson)
        {
            Person temp;
            Person[] result = new Person[arrayPerson.Length];
            


            for (int i = (arrayPerson.Length - 1); i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (arrayPerson[j-1].firstName.CompareTo(arrayPerson[j].firstName) > 0)
                    {
                        temp = arrayPerson[j - 1];
                        arrayPerson[j - 1] = arrayPerson[j];
                        arrayPerson[j] = temp;
                     
                    }
                    else if (arrayPerson[j - 1].firstName.CompareTo(arrayPerson[j].firstName) == 0)
                    {
                        if (arrayPerson[j - 1].lastName.CompareTo(arrayPerson[j].lastName) > 0)
                        {
                            temp = arrayPerson[j - 1];
                            arrayPerson[j - 1] = arrayPerson[j];
                            arrayPerson[j] = temp;
                        }
                    }
                }
            }
            result = arrayPerson;
            return result;
        }
    }
    

    interface IPersonStrategy
    {
        Person[] Sort(Person[] array);
    }

    //Comparatore delle Persone
    class PersonComparator
    {
        public Person[] Compare(Person[] arrayPerson, IPersonStrategy strategy){
            Person[] pArray;
            pArray = strategy.Sort(arrayPerson);
            return pArray;

        }
    }

    //Classe Persona con attributi: Età, Nome, Cognome
    class Person
    {
        public int age;
        public string firstName;
        public string lastName;

        public Person(int a, string firstName, string lastName)
        {
            this.age = a;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return this.firstName + " " + this.lastName + " " + this.age;
        }
    }
}
