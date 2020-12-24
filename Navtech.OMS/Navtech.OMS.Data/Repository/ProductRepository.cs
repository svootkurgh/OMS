using Navtech.OMS.Data.Contracts;
using Navtech.OMS.Entities;
using Navtech.OMS.Data.Infrastructure;

namespace Navtech.OMS.Data.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}