using System;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Student : User, IComparable<Student>
    {

        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


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

        public void AddGrade(Grade grade)
        {
            if (grade.StudentID == 0)
            {
                grade.StudentID = StudentID;
            }
            else
            {
                throw new ArgumentException("Grade", "Grade belongs to a different student");
            }
        }

        protected override bool SetPassword(string pswd)
        {
            if (pswd.Length >= 6)
            {
                _password = pswd;
                return true;
            }
            return false;
        }
    }
}
