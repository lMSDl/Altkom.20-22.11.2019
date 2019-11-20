using Altkom._20_22._11.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Altkom._20_22._11.CSharp.Exercises
{
    public class Exercise1
    {
        private IList<Person> Persons { get; }
        private string _lastOutout;

        public Exercise1()
        {
            Persons = new List<Person> { new Person { Id = 1, BirthDate = new DateTime(1990, 12, 3), Gender = 0, FirstName = "Ewa", LastName = "Adamska" },
                new Person { Id = 1, BirthDate = new DateTime(1988, 8, 21), Gender = 1, FirstName = "Adam", LastName = "Adamska" } };
        }

        public void Start()
        {
            ShowPersons();
            while (ReadCommand(Console.ReadLine()))
            {
            }
        }

        public void ShowPersons()
        {
            WriteLine(Persons.OrderBy(x => x.LastName).Select(x => x.ToString()).Aggregate((a, b) => $"{a}\n{b}"));
        }

        public bool ReadCommand(string input)
        {
            //TODO 1 Jeśli użytkownik wpisze "edit {id}", gdzie {id} to identyfikator osoby, wyszukać tę osobę na liście i uruchomić funkcję EditPerson
            //TODO 2 Po wprowadzeniu zmian, wyświetlić ponownie listę osób

            switch (input)
            {
                case "exit":
                    return false;
                default:
                    WriteLine(_lastOutout);
                    break;
            }
            return true;
        }

        public void EditPerson(Person person)
        {
            WriteLine(nameof(Person.FirstName));
            SendKeys.SendWait(person.FirstName);
            person.FirstName = Console.ReadLine();

            //TODO 3 Uzupełnić kod o edycję Person.LastName oraz Person.BirthDate
        }

        private void WriteLine(string outout)
        {
            Console.Clear();
            Console.WriteLine(outout);
            Console.WriteLine();
            _lastOutout = outout;
        }
    }
}
