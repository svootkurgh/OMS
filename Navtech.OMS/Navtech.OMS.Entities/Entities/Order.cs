using Newtonsoft.Json;
using System.Collections.Generic;

namespace Navtech.OMS.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}