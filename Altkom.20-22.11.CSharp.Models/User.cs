namespace Altkom._20_22._11.CSharp.Models
{
    public class User
    {
        public System.Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
