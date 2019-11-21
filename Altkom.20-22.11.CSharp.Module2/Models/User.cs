using System;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public abstract class User
    {
        //TODO 8.2a: Zapewnij dostęp do pola dla klas dziedziczących
        private string _password = Guid.NewGuid().ToString();

        public string UserName { get; set; }
        public string Password
        {
            //TODO 8.1b: Uzyj metody SetPassword. Rzuć wyjątek jeśli hasło nie spełnia wymagań.
            set => _password = value;
        }
        public bool VerifyPassword(string pass)
        {
            return (string.Compare(pass, _password) == 0);
        }


        //TODO 8.1a: Zdefiniuj abstrakcyjną metodę SetPassword do ustawiania hasła. Metoda zwraca wartość bool mówiącą czy hasło spełnia wymagania.
        //Nauczyciele i Studenci będą mieć różne wymagania co do złożności hasła
    }
}
