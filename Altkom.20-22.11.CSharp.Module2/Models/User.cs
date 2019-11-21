using System;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public abstract class User
    {
        protected string _password = Guid.NewGuid().ToString();

        public string UserName { get; set; }
        public string Password
        {
            set {
                if (!SetPassword(value))
                    throw new Exception("Password not complex enough");
            }
        }
        public bool VerifyPassword(string pass)
        {
            return (string.Compare(pass, _password) == 0);
        }


        protected abstract bool SetPassword(string pswd);
    }
}
