namespace ElkoProvider.Models
{
    public class ElkoProduct
    {
        public string id { get; set; }
        public string name { get; set; }
        public string manufacturerCode { get; set; }
        public string vendorName { get; set; }
        public string vendorCode { get; set; }
        public string catalog { get; set; }
        public string quantity { get; set; }
        public decimal price { get; set; }
        public decimal discountPrice { get; set; }
        public string imagePath { get; set; }
        public string thumbnailImagePath { get; set; }
        public string fullDsc { get; set; }
        public string currency { get; set; }
        public string httpDescription { get; set; }
        public string packagingQuantity { get; set; }
        public string warranty { get; set; }
        public string eanCode { get; set; }
        public string obligatoryKit { get; set; }
        public int reservedQuantity { get; set; }
        public string promDate { get; set; }
        public string promQuant { get; set; }
        public string quantityForPrice2 { get; set; }
        public string price2 { get; set; }
        public string lotNumber { get; set; }
    }
}