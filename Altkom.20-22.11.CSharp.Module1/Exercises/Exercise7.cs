using Altkom._20_22._11.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Altkom._20_22._11.CSharp.Module1
{
    public class Exercise7
    {
        private IList<Person> Persons { get; }
        private string _lastOutout;
        private static readonly string _tableFormat = "{0,-3} {1,-15} {2,-15} {3,-10}";
        private enum Commands { add = 100, delete = 200, edit = 300, exit = 0 };
        private OutputDelegate Output;

        public Exercise7()
        {
            Persons = new List<Person> { new Person { Id = 1, BirthDate = new DateTime(1990, 12, 3), Gender = 0, FirstName = "Ewa", LastName = "Adamska" },
                new Person { Id = 2, BirthDate = new DateTime(1988, 8, 21), Gender = 1, FirstName = "Adam", LastName = "Adamska" },
            new Person { Id = 3, BirthDate = new DateTime(1988, 8, 21), Gender = 1, FirstName = "Piotr", LastName = "Piotrowski" }};

            //Persons.Clear();
        }

        public void Start()
        {
            Output += WriteLine;
            Output += SaveOutput;

            var test = Output("test");
            
            ShowPersons();
            while (ReadCommand(Console.ReadLine()))
            {
            }
        }

        public void ShowPersons()
        {
            var strings = new List<string>
            {
                string.Format(_tableFormat, nameof(Person.Id), nameof(Person.LastName), nameof(Person.FirstName), "Age")
            };

            strings.AddRange(Persons.OrderBy(x => x.LastName)
                .Select(x => string.Format(_tableFormat, x.Id, x.LastName, x.FirstName, new DateTime(DateTime.Now.Subtract(x.BirthDate).Ticks).Year)));
            //if (query.Any())
            //    strings.Add(query.Aggregate((a, b) => $"{a}\n{b}"));

            Output(string.Join("\n", strings));
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
                    Output?.Invoke(_lastOutout);
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
                    Output?.Invoke(_lastOutout);
                    return true;
                case Commands.exit:
                    return false;
                default:
                    Output?.Invoke(_lastOutout);
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
            Output?.Invoke($"Do you want to delete {person.LastName} {person.FirstName}? [y/n]");
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
            person.FirstName = ReadPersonData(nameof(Person.FirstName), person.FirstName, input => input);
            person.LastName = ReadPersonData(nameof(Person.LastName), person.LastName, input => input);
            person.BirthDate = ReadPersonData<DateTime?>(nameof(Person.BirthDate), person.BirthDate.ToShortDateString(),
                input =>
                {
                    if(DateTime.TryParse(input, out var output))
                    {
                        if(output < DateTime.Today)
                        {
                            return output;
                        }
                        return null;
                    }
                    return null;
                }).Value;
        }

        //private delegate T PersonDataParser<T>(string input);

        private T ReadPersonData<T>(string header, string currentValue, Func<string, T> parser )//PersonDataParser<T> parser)
        {
            string line;
            T result;
            do
            {
                do
                {
                    Output?.Invoke(header);
                    SendKeys.SendWait(currentValue);
                    line = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(line));
            } while ((result = parser.Invoke(line)) == null);

            return result;
        }

        private delegate int OutputDelegate(string output);

        private int WriteLine(string outout)
        {
            Console.Clear();
            Console.WriteLine(outout);
            Console.WriteLine();
            return 100;
        }
        private int SaveOutput(string outout)
        {
            _lastOutout = outout;
            return 1000;
        }
    }
}
