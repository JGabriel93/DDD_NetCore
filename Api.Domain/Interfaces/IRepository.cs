using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<Guid> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<bool> ExistsAsync(Guid id);
    }
}
