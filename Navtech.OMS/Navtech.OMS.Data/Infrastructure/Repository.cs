using Navtech.OMS.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Navtech.OMS.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) 
                throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).AsEnumerable();
        }

        public virtual T Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            _unitOfWork.Db.SaveChanges();
            return obj;
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Db.SaveChanges();
        }

        public virtual void UpdateAll(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            }
            _unitOfWork.Db.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            IEnumerable<T> entities = this.GetAll(filter);
            foreach (T entity in entities)
            {
                if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            _unitOfWork.Db.SaveChanges();
        }
    }
}