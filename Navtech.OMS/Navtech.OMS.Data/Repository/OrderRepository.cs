using Navtech.OMS.Data.Contracts;
using Navtech.OMS.Data.Infrastructure;
using Navtech.OMS.Entities;

namespace Navtech.OMS.Data.Repository
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}