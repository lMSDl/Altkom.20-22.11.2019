namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public struct Student
    //TODO 4.1b: Przekonwertuj na klasę i dodaj konstruktory (parametrowy i domyślny). Zamień właściwość Password na tylko do zapisu, dodaj metodę VerifyPassword.
    {
        public int StudentID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
