namespace Navtech.OMS.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }

        public int? BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }

    }
}