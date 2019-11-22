using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom._20_22._11.CSharp.IServices
{
    public interface ICrudService<T>
    {
        Task<T> CreateAsync(T entity);

        Task<ICollection<T>> ReadAsync();

        Task<T> ReadAsync<TId>(TId id) where TId : IComparable;

        Task UpdateAsync<TId>(TId id, T entity) where TId : IComparable;

        Task DeleteAsync<TId>(TId id) where TId : IComparable;
    }
}
