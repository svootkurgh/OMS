using Navtech.OMS.Data.Contracts;
using Navtech.OMS.Entities;
using Navtech.OMS.Data.Infrastructure;

namespace Navtech.OMS.Data.Repository
{
    public class BuyerRepository : Repository<Buyer>
    {
        public BuyerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}