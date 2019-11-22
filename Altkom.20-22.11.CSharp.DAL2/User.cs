namespace Altkom._20_22._11.CSharp.DAL2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public Guid ApplicationId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public bool IsAnonymous { get; set; }

        public DateTime LastActivityDate { get; set; }

        [Required]
        [StringLength(20)]
        public string UserPassword { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
