﻿using Altkom._20_22._11.CSharp.Models;
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
            var command = input.Split(' ');

            switch (command[0])
            {
                case "edit":
                    var person = Persons.Single(p => p.Id == int.Parse(command[1]));
                    EditPerson(person);
                    ShowPersons();
                    break;
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

            WriteLine(nameof(Person.LastName));
            SendKeys.SendWait(person.LastName);
            person.LastName = Console.ReadLine();

            WriteLine(nameof(Person.BirthDate));
            SendKeys.SendWait(person.BirthDate.ToShortDateString());
            person.BirthDate = DateTime.Parse(Console.ReadLine());
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
