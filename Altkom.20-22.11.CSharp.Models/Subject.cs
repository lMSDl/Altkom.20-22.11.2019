namespace Altkom._20_22._11.CSharp.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
