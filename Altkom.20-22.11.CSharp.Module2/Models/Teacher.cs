namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Teacher
    {
        private string _password;

        public int TeacherID { get; set; }
        public string UserName { get; set; }
        public string Password { set => _password = value; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }


        public bool VerifyPassword(string password)
        {
            return _password == password;
        }
        
        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string @class)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = @class;
        }
    }
}
