using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Navtech.OMS.Data.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        T Insert(T entity);
        void Update(T entity);
        void UpdateAll(IList<T> entities);
        void Delete(Expression<Func<T, bool>> filter);
    }
}