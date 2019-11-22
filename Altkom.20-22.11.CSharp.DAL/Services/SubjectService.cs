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
    public class SubjectService : BaseService<Subject>
    {
        protected override bool CompareId<TId>(TId id, Subject entity)
        {
            return int.Parse(id.ToString()) == entity.Id;
        }

        protected override DbSet<Subject> DbSet(SchoolDB context)
        {
            return context.Subjects;
        }

        protected override void UpdateGraph(SchoolDB context, Subject entity)
        {
            context.UpdateGraph(entity);
        }
    }
}
