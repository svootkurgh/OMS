using Navtech.OMS.Data.Contracts;
using System.Data.Entity;

namespace Navtech.OMS.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OMSContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new OMSContext();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
