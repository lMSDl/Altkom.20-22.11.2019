﻿using Altkom._20_22._11.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Altkom._20_22._11.CSharp.Module1
{
    public class Exercise6
    {
        private IList<Person> Persons { get; }
        private string _lastOutout;
        private static readonly string _tableFormat = "{0,-3} {1,-15} {2,-15} {3,-10}";
        private enum Commands { add = 100, delete = 200, edit = 300, exit = 0 };

        public Exercise6()
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
            WriteLine(
                string.Format(_tableFormat, nameof(Person.Id), nameof(Person.LastName), nameof(Person.FirstName), "Age") + "\n" +
                Persons.OrderBy(x => x.LastName)
                .Select(x => string.Format(_tableFormat, x.Id, x.LastName, x.FirstName, new DateTime(DateTime.Now.Subtract(x.BirthDate).Ticks).Year))
                .Aggregate((a, b) => $"{a}\n{b}"));
        }

        public bool ReadCommand(string input)
        {
            var command = input.Split(' ');
            Person person;
            var enumCommand = Enum.Parse(typeof(Commands), command[0]);
            switch (enumCommand)
            {
                case Commands.delete:
                    person = FindPerson(command);
                    if (person != null)
                    {
                        DeletePerson(person);
                        break;
                    }
                    WriteLine(_lastOutout);
                    return true;
                case Commands.add:
                    AddPerson();
                    break;
                case Commands.edit:
                    person = FindPerson(command);
                    if (person != null)
                    {
                        EditPerson(person);
                        break;
                    }
                    WriteLine(_lastOutout);
                    return true;
                case Commands.exit:
                    return false;
                default:
                    WriteLine(_lastOutout);
                    return true;
            }
            ShowPersons();
            return true;
        }

        private Person FindPerson(string[] command)
        {
            if (command.Length > 1 && int.TryParse(command[1], out var id))
            {
                return Persons.SingleOrDefault(x => x.Id == id);
            }
            return null;
        }

        public void DeletePerson(Person person)
        {
            WriteLine($"Do you want to delete {person.LastName} {person.FirstName}? [y/n]");
            var key = Console.ReadKey();
            if (key.KeyChar == 'y')
            {
                Persons.Remove(person);
            }
            else if (key.KeyChar == 'n')
            {
                return;
            }
            else
            {
                DeletePerson(person);
            }
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
            person.FirstName = ReadPersonData(nameof(Person.FirstName), person.FirstName);
            person.LastName = ReadPersonData(nameof(Person.LastName), person.LastName);

            DateTime birthDate;
            string date;
            do
            {
                date = ReadPersonData(nameof(Person.BirthDate), person.BirthDate.ToShortDateString());
            }
            while (!DateTime.TryParse(date, out birthDate));
            person.BirthDate = birthDate;
        }

        private string ReadPersonData(string header, string currentValue)
        {
            string line;
            do
            {
                WriteLine(header);
                SendKeys.SendWait(currentValue);
                line = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(line));
            return line;
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
