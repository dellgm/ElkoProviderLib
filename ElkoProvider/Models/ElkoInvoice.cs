using System.Collections.Generic;

namespace ElkoProvider.Models
{
    public class ElkoInvoice
    {
        public string invoiceId { get; set; }
        public int dateCreate { get; set; }
        public string trackingDPD { get; set; }
        public ElkoInvoiceAdditionalinfo additionalInfo { get; set; }
        public List<ElkoInvoiceDetail> details { get; set; }
    }

    public class ElkoInvoiceAdditionalinfo
    {
        public string amountWithVAT { get; set; }
        public string amountWithoutVAT { get; set; }
        public string vatAmount { get; set; }
        public string currency { get; set; }
        public int dueDate { get; set; }
        public string packageNumber { get; set; }
        public string amountOpen { get; set; }
        public string addressNummber { get; set; }
        public string addressLine { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
    }

    public class ElkoInvoiceDetail
    {
        public int lineId { get; set; }
        public string elkoCode { get; set; }
        public string orderNumber { get; set; }
        public string description { get; set; }
        public string manufacturerCode { get; set; }
        public int quantityShipped { get; set; }
        public string price { get; set; }
        public string copyrightTax { get; set; }
        public string deliveryInstructions { get; set; }
        public string eanCode { get; set; }
        public string vatRate { get; set; }
        public string[] serials { get; set; }
    }
}



