using Altkom._20_22._11.CSharp.DAL;
using Altkom._20_22._11.CSharp.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Altkom._20_22._11.CSharp.WebAPI.Controllers
{
    public class GradesController : BaseController<Grade, Guid>
    {
        protected override BaseService<Grade> Service => new GradeService();

        [HttpGet]
        [Route("api/Students/{studentId}/Grades")]
        public Task<List<Grade>> GetForStudent(Guid studentId)
        {
            return Service.ReadAsync(x => x.Where(g => g.StudentUserId == studentId).ToList());
        }
    }
}
