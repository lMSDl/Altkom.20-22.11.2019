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
    public class GradeService : BaseService<Grade>
    {
        protected override bool CompareId<TId>(TId id, Grade entity)
        {
            return int.Parse(id.ToString()) == entity.Id;
        }

        protected override DbSet<Grade> DbSet(SchoolDB context)
        {
            return context.Grades;
        }

        protected override void UpdateGraph(SchoolDB context, Grade entity)
        {
            context.UpdateGraph(entity);
        }
    }
}
