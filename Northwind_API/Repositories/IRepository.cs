using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Northwind_API.Repositories
{
    public interface IRepository<T>
    {
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> SearchForAsync(Expression<Func<T, bool>> predicate);

        Task<bool?> SaveAsync(T entity);
        Task<bool?> SaveAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}