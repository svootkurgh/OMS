namespace Navtech.OMS.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public string Image { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public string AvailableQuantity { get; set; }
        public int OrderedQuantity { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}