using System;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Teacher
    {
        private string _password = Guid.NewGuid().ToString();

        public int TeacherID { get; set; }
        public string UserName { get; set; }
        public string Password
        {
            set
            {
                _password = value;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        public bool VerifyPassword(string pass)
        {
            return (string.Compare(pass, _password) == 0);
        }

        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        public void AddToClass(Student student)
        {
            if (student.TeacherID == 0)
                student.TeacherID = TeacherID;
            else
                throw new ArgumentException(nameof(Student), "Student already in class");
        }

        public void RemoveFromClass(Student student)
        {
            if (student.TeacherID == TeacherID)
                student.TeacherID = 0;
            else
                throw new ArgumentException(nameof(Student), "Student is not assigned to this class");
        }
    }
}
