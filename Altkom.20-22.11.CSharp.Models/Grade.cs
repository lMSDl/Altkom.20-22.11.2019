namespace Altkom._20_22._11.CSharp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grade
    {
        public int Id { get; set; }
        public string Assessment { get; set; }
        public string Comments { get; set; }
        public System.DateTime AssessmentDate { get; set; }
        public int SubjectId { get; set; }
        public System.Guid StudentUserId { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
