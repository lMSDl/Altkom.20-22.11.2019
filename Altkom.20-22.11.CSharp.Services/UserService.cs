using Altkom._20_22._11.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom._20_22._11.CSharp.Services
{
    public class UserService
    {
        private CustomHttpClient customHttpClient;

        public UserService()
        {
            customHttpClient = new CustomHttpClient();
        }

        public Task<User> GetUserAsync(string username, string password)
        {
            return customHttpClient.Post("api/users/login", new User { UserName = username, UserPassword = password });
        }

    }
}
