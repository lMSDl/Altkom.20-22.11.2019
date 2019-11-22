using Altkom._20_22._11.CSharp.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Altkom._20_22._11.CSharp.DAL.Services
{
    public abstract class BaseService<T> : ICrudService<T> where T : class
    {
        public async Task<T> CreateAsync(T entity)
        {
            using (var context = new SchoolDB())
            {
                entity = DbSet(context).Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync<TId>(TId id) where TId : IComparable
        {
            using (var context = new SchoolDB())
            {
                Guid userId = Guid.Parse(id.ToString());
                var entity = DbSet(context).SingleOrDefault(x => CompareId(id, x));
                if (entity != null)
                {
                    DbSet(context).Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public Task<ICollection<T>> ReadAsync()
        {
            using (var context = new SchoolDB())
            {
                return Task.FromResult<ICollection<T>>(DbSet(context).ToList());
            }
        }

        public Task<M> ReadAsync<M>(Func<DbSet<T>, M> query)
        {
            using (var context = new SchoolDB())
            {
                return Task.FromResult(query(DbSet(context)));
            }
        }

        public Task<T> ReadAsync<TId>(TId id) where TId : IComparable
        {
            using (var context = new SchoolDB())
            {
                return Task.FromResult(DbSet(context).SingleOrDefault(x => CompareId(id, x)));
            }
        }

        public async Task UpdateAsync<TId>(TId id, T entity) where TId : IComparable
        {
            using (var context = new SchoolDB())
            {
                UpdateGraph(context, entity);
                await context.SaveChangesAsync();
            }
        }

        protected abstract DbSet<T> DbSet(SchoolDB context);

        protected abstract bool CompareId<TId>(TId id, T entity);

        protected abstract void UpdateGraph(SchoolDB context, T entity);

    }
}
