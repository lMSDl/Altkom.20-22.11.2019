using Altkom._20_22._11.CSharp.Module2.Services;
using System;
using System.Linq;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Teacher : User
    {
        public const int MAX_CLASS_SIZE = 9;

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
            var numberOfStudents = DataSource.Students.Count(s => s.TeacherID == SessionContext.CurrentTeacher.TeacherID);
            if (numberOfStudents >= MAX_CLASS_SIZE)
                throw new ClassFullException(SessionContext.CurrentTeacher.Class, "Class full");

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

        protected override bool SetPassword(string pswd)
        {
            if(pswd.Length >= 8 && pswd.Count(c => char.IsDigit(c)) >= 2)
            {
                _password = pswd;
                return true;
            }
            return false;
        }
    }
}
