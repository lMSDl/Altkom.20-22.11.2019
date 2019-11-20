using System;

namespace Altkom._20_22._11.CSharp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-3} {1,-15} {2,-15} {3,-10}", Id, LastName, FirstName, BirthDate.ToShortDateString());
        }
    }
}
