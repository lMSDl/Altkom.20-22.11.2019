namespace Altkom._20_22._11.CSharp.Module2.Models
{
    //TODO 4.1c: Przekonwertuj na klasę i dodaj konstruktor. Zamień właściwość Password na tylko do zapisu, dodaj metodę VerifyPassword.
    public struct Teacher
    {
        public int TeacherID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
    }
}
