using Altkom._20_22._11.CSharp.DAL;
using Altkom._20_22._11.CSharp.DAL.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Altkom._20_22._11.CSharp.WebAPI.Controllers
{
    public class StudentsController : BaseController<Student, Guid>
    {
        protected override BaseService<Student> Service => new StudentService();
    }


    [HttpGet]
    [Route("api/Teachers/{studentId}/Students")]
    public Task<List<Student>> GetForTeacher(Guid userId)
    {

    }
}
