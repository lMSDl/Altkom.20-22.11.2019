using Altkom._20_22._11.CSharp.DAL;
using Altkom._20_22._11.CSharp.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Altkom._20_22._11.CSharp.WebAPI.Controllers
{
    public abstract class BaseController<T1, T2> : ApiController where T1 : class where T2 : IComparable
    {
        protected abstract BaseService<T1> Service { get; }

        [HttpGet]
        public Task<ICollection<T1>> Get()
        {
            return Service.ReadAsync();
        }

        [HttpGet]
        public Task<T1> Get(T2 id)
        {
            return Service.ReadAsync(id);
        }

        [HttpDelete]
        public Task Delete(T2 id)
        {
            return Service.DeleteAsync(id);
        }

        [HttpPost]
        public Task<T1> Post(T1 entity)
        {
            return Service.CreateAsync(entity);
        }

        [HttpPut]
        public Task Put(T2 id, T1 entity)
        {
            return Service.UpdateAsync(id, entity);
        }
    }
}
