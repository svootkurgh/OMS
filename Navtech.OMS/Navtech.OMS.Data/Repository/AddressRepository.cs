using Navtech.OMS.Data.Contracts;
using Navtech.OMS.Entities;
using Navtech.OMS.Data.Infrastructure;

namespace Navtech.OMS.Data.Repository
{
    public class AddressRepository : Repository<Address>
    {
        public AddressRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}