using Altkom._20_22._11.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Altkom._20_22._11.CSharp.Module1
{
    public class Exercise4
    {
        private IList<Person> Persons { get; }
        private string _lastOutout;

        public Exercise4()
        {
            Persons = new List<Person> { new Person { Id = 1, BirthDate = new DateTime(1990, 12, 3), Gender = 0, FirstName = "Ewa", LastName = "Adamska" },
                new Person { Id = 2, BirthDate = new DateTime(1988, 8, 21), Gender = 1, FirstName = "Adam", LastName = "Adamska" } };
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
            //TODO 1 Jeśli użytkownik wpisze "delete {id}", gdzie {id} to identyfikator osoby, wyszukać tę osobę na liście i uruchomić funkcję DeletePerson

            var command = input.Split(' ');
            switch (command[0])
            {
                case "add":
                    AddPerson();
                    break;
                case "edit":
                    if (command.Length > 1)
                    {
                        if (int.TryParse(command[1], out var id))
                        {
                            var person = Persons.SingleOrDefault(x => x.Id == id);
                            if (person != null)
                            {
                                EditPerson(person);
                                break;
                            }
                        }
                    }
                    WriteLine(_lastOutout);
                    return true;
                case "exit":
                    return false;
                default:
                    WriteLine(_lastOutout);
                    return true;
            }
            ShowPersons();
            return true;
        }

        public void DeletePerson(Person person)
        {
            //TODO 2 Wyświetlić zapytanie o potwierdzenie decyzji
            //TODO 3 W przypadku potwierdzenia usunąć obiekt z listy, w przeciwnym razie przerwać funkcję
        }

        public void AddPerson()
        {
            var person = new Person();
            EditPerson(person);
            person.Id = Persons.Max(x => x.Id) + 1;
            Persons.Add(person);
        }

        public void EditPerson(Person person)
        {
            string line;
            do
            {
                WriteLine(nameof(Person.FirstName));
                SendKeys.SendWait(person.FirstName);
                line = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(line));
            person.FirstName = line;

            do
            {
                WriteLine(nameof(Person.LastName));
                SendKeys.SendWait(person.LastName);
                line = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(line));
            person.LastName = line;

            DateTime birthDate;
            do
            {
                WriteLine(nameof(Person.BirthDate));
                SendKeys.SendWait(person.BirthDate.ToShortDateString());
            }
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate));
            person.BirthDate = birthDate;
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
