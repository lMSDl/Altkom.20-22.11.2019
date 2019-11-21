namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Student
    {
        private string _password;
        private string _userName;

        public int StudentID { get; set; }
        public string UserName { get => _userName;
            set {
                if(_userName != value)
                    _userName = value;
            }
        }
        //get i set pozwalają na dopisanie dodatkowej logiki
        //public string Password { set { _password = value; } }
        public string Password { set => _password = value; }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool VerifyPassword(string password)
        {
            return _password == password;
        }


        public Student(int studentID, string userName, string password, int teacherID, string firstName, string lastName)
        {
            StudentID = studentID;
            UserName = userName;
            Password = password;
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
        }

        public Student()
        {
        }
    }
}
