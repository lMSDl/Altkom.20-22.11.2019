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
    public class StudentService : BaseService<Student>
    {
        protected override bool CompareId<TId>(TId id, Student entity)
        {
            return Guid.Parse(id.ToString()) == entity.UserId;
        }

        protected override DbSet<Student> DbSet(SchoolDB context)
        {
            return context.Students;
        }

        protected override void UpdateGraph(SchoolDB context, Student entity)
        {
            context.UpdateGraph(entity);
        }
    }
}
