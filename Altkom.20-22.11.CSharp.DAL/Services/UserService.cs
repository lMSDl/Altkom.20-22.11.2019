using Altkom._20_22._11.CSharp.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using RefactorThis.GraphDiff;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Altkom._20_22._11.CSharp.DAL.Services
{
    public class UserService : BaseService<User>
    {
        protected override bool CompareId<TId>(TId id, User entity)
        {
            return Guid.Parse(id.ToString()) == entity.UserId;
        }

        protected override DbSet<User> DbSet(SchoolDB context)
        {
            return context.Users;
        }

        protected override void UpdateGraph(SchoolDB context, User entity)
        {
            context.UpdateGraph(entity);
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            using (var context = new SchoolDB())
            {
                var user = await DbSet(context).Include(x => x.Student).Include(x => x.Teacher).SingleOrDefaultAsync(x => x.UserName == username);
                if (user != null)
                    if (user.UserPassword == password)
                        return user;
                return null;
            }
        }
    }
}
