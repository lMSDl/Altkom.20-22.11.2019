using Altkom._20_22._11.CSharp.DAL;
using Altkom._20_22._11.CSharp.DAL.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Altkom._20_22._11.CSharp.WebAPI.Controllers
{
    public class UsersController : BaseController<User, Guid>
    {
        protected override BaseService<User> Service => new UserService();

        [HttpPost]
        [Route("api/users/login")]
        public Task<User> Get(User user)
        {
            return ((UserService)Service).GetUserAsync(user.UserName, user.UserPassword);
        }
    }
}
