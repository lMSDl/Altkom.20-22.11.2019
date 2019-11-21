using System;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Teacher : User
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

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
            {
                student.TeacherID = TeacherID;
            }
            else
            {
                throw new ArgumentException("Student", "Student is already assigned to a class");
            }
        }

        public void RemoveFromClass(Student student)
        {
            if (student.TeacherID == TeacherID)
            {
                student.TeacherID = 0;
            }
            else
            {
                throw new ArgumentException("Student", "Student is not assigned to this class");
            }
        }

        //TODO 8.2c: Zaimplementuj metodę SetPassword. Zapewnij, że ustawiane hasło będzie mieć co najmniej 8 znaków, w tym co najmniej 2 cyfry.
    }
}
