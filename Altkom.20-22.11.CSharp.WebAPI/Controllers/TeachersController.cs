using Altkom._20_22._11.CSharp.DAL;
using Altkom._20_22._11.CSharp.DAL.Services;
using System;

namespace Altkom._20_22._11.CSharp.WebAPI.Controllers
{
    public class TeacherController : BaseController<Teacher, Guid>
    {
        protected override BaseService<Teacher> Service => new TeacherService();
    }
}
