using Newtonsoft.Json;
using System.Collections.Generic;

namespace Navtech.OMS.Entities
{
    public class Buyer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public ICollection<Address> Addresses { get; set; }

        public Buyer()
        {
            Orders = new List<Order>();
            Addresses = new List<Address>();
        }
    }
}