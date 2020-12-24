using Navtech.OMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Navtech.OMS.Api.Models
{
    public class OrderModel
    {
        public List<Address> Addresses { get; set; }
        public Buyer Buyer { get; set; }
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public List<string> ValidationMessages { get; set; }

        public OrderModel()
        {
            Addresses = new List<Address>();
            Products = new List<Product>();
            ValidationMessages = new List<string>();
            Buyer = new Buyer();
            Order = new Order();
        }

        public bool IsValid()
        {
            bool isValid = true;

            if (!Addresses.Any())
                ValidationMessages.Add("Response doesn't have addresses information");

            if (Buyer == null)
                ValidationMessages.Add("Response doesn't have Buyer information");

            if (!Products.Any())
                ValidationMessages.Add("Response doesn't have Products");

            //TODO: Have to add validations for all the properties for database entities have dependency with saving into database.

            return isValid;
        }

    }
}