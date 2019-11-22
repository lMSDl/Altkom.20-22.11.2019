namespace Altkom._20_22._11.CSharp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public System.Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
        public virtual User User { get; set; }
    }
}
