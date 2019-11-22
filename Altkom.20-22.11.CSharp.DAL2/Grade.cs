namespace Altkom._20_22._11.CSharp.DAL2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grade
    {
        public int Id { get; set; }

        [Required]
        public string Assessment { get; set; }

        public string Comments { get; set; }

        public DateTime AssessmentDate { get; set; }

        public int SubjectId { get; set; }

        public Guid StudentUserId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
