﻿using Altkom._20_22._11.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Altkom._20_22._11.CSharp.Module1
{
    public class Exercise2
    {
        private IList<Person> Persons { get; }
        private string _lastOutout;

        public Exercise2()
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
                    if(command.Length > 1 && int.TryParse(command[1], out var id))
                    {
                        var person = Persons.SingleOrDefault(x => x.Id == id);
                        if(person != null)
                            EditPerson(person);
                    }
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
            string input;
            do {
                WriteLine(nameof(Person.FirstName));
                SendKeys.SendWait(person.FirstName);
            } while (string.IsNullOrWhiteSpace(input = Console.ReadLine()));
            person.FirstName = input;

            do
            {
                WriteLine(nameof(Person.LastName));
                SendKeys.SendWait(person.LastName);
            } while (string.IsNullOrWhiteSpace(input = Console.ReadLine()));
            person.LastName = input;

            DateTime dateTime;
            do
            {
                WriteLine(nameof(Person.BirthDate));
                SendKeys.SendWait(person.BirthDate.ToShortDateString());
                
            } while (!DateTime.TryParse(Console.ReadLine(), out dateTime));
            person.BirthDate = dateTime;
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
