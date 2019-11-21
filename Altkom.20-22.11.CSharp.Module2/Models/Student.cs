using System;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Student : IComparable<Student>
    {
        private string _password = Guid.NewGuid().ToString();

        public int StudentID { get; set; }
        public string UserName { get; set; }
        public string Password
        {
            set => _password = value;
        }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool VerifyPassword(string pass)
        {
            return (string.Compare(pass, _password) == 0);
        }

        public Student(int studentID, string userName, string password, string firstName, string lastName, int teacherID)
        {
            StudentID = studentID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherID;
        }
        public Student()
        {
        }

        public int CompareTo(Student other)
        {
            var thisStudentsFullName = LastName + FirstName;
            var otherStudentsFullName = other.LastName + other.FirstName;
            return (string.Compare(thisStudentsFullName, otherStudentsFullName));
        }

        //TODO 6.2c: Napisz funkcję AddGrade(Grade grade) przypisującą ocenę studentowi. Jeśli ocena jest już przypisana do jakiegoś studenta rzuć wyjątek.
    }
}
