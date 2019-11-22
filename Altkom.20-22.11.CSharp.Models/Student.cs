
namespace Altkom._20_22._11.CSharp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public System.Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageName { get; set; }
    
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual User User { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
