namespace ElkoProvider.Models
{
    public class ElkoAvailabilityAndPrice
    {
        public int productId { get; set; }
        public string stockQuantity { get; set; }
        public Incoming incoming { get; set; }
        public Prices prices { get; set; }
    }
    public class Prices
    {
        public string currency { get; set; }
        public decimal price { get; set; }
        public decimal discountPrice { get; set; }
        public decimal copyrightTax { get; set; }
    }
    public class Incoming
    {
        public string quantity { get; set; }
        public string expectedDate { get; set; }
    }
}