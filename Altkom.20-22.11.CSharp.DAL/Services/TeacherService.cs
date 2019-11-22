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
    public class TeacherService : BaseService<Teacher>
    {
        protected override bool CompareId<TId>(TId id, Teacher entity)
        {
            return Guid.Parse(id.ToString()) == entity.UserId;
        }

        protected override DbSet<Teacher> DbSet(SchoolDB context)
        {
            return context.Teachers;
        }

        protected override void UpdateGraph(SchoolDB context, Teacher entity)
        {
            context.UpdateGraph(entity);
        }

        public Task<ICollection<Student>> GetStudentsForTeacher(Guid userId)
        {

        }
    }
}
