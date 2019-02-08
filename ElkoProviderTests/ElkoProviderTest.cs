using ElkoProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ElkoProviderTests
{
    [TestClass]
    public class ElkoProviderTest
    {
        [TestMethod]
        public void ElkoBaseUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";

            // act
            var elko = FluentElkoService.WithLogin("username", "password").Api(baseUrl);

            //assert
            Assert.AreEqual(baseUrl, FluentElkoService.BaseUrl);
        }

        [TestMethod]
        public void ElkoRequestTokenUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string requestTokenUrl = "https://api.elkogroup.com/v3.0/api/Token";

            // act
            var elko = FluentElkoService.WithLogin("username", "password").Api(baseUrl).WithTokenUrl(tokenUrl);

            //assert
            Assert.AreEqual(requestTokenUrl, FluentElkoService.RequestTokenUrl);
        }

        [TestMethod]
        public void ElkoCategoriesUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string categoriesUrl = "/v3.0/api/Catalog/Categories";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Categories";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().Categories(categoriesUrl);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoVendorsUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string vendorsUrl = "/v3.0/api/Catalog/Vendors";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Vendors";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().Vendors(vendorsUrl);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoProductsUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string productsUrl = "/v3.0/api/Catalog/Products";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Products";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().Products(productsUrl);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoProductsWithElkoCodesUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string productsUrl = "/v3.0/api/Catalog/Products";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Products?elkoCode=123,987";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().Products(productsUrl).WithElkoCodes("123", "987");

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoProductsWithVendorCodesUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string productsUrl = "/v3.0/api/Catalog/Products";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Products?vendorCode=SA,SM";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().Products(productsUrl).WithVendorCodes("SA", "SM");

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoProductsWithCatalogCodesUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string productsUrl = "/v3.0/api/Catalog/Products";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Products?catalog=C1,C2";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().Products(productsUrl).WithCatalogCodes("C1", "C2");

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoProductDescriptionUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string productDescriptionUrl = "/v3.0/api/Catalog/Products/{elkoCode}/Description";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Products/{elkoCode}/Description";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().ProductDescription(productDescriptionUrl);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoProductDescriptionWithElkoCodeUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string productDescriptionUrl = "/v3.0/api/Catalog/Products/{elkoCode}/Description";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/Products/123456/Description";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().ProductDescription(productDescriptionUrl).WithElkoCode("123456");

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoAvailabilityAndPriceUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string availabilityAndPriceUrl = "/v3.0/api/Catalog/AvailabilityAndPrice/{type}";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/{type}";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoAvailabilityAndPriceWithTypeUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string availabilityAndPriceUrl = "/v3.0/api/Catalog/AvailabilityAndPrice/{type}";
            string requestUrl1 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/Availability";
            string requestUrl2 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/AvailabilityIncoming";
            string requestUrl3 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/AvailabilityIncomingPrice";
            string requestUrl4 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/AvailabilityPrice";

            // act and assert

            var elko1 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl).WithType(ElkoType.Availability);

            Assert.AreEqual(requestUrl1, FluentElkoService.RequestUrl);

            var elko2 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl).WithType(ElkoType.AvailabilityIncoming);

            Assert.AreEqual(requestUrl2, FluentElkoService.RequestUrl);

            var elko3 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl).WithType(ElkoType.AvailabilityIncomingPrice);

            Assert.AreEqual(requestUrl3, FluentElkoService.RequestUrl);

            var elko4 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl).WithType(ElkoType.AvailabilityPrice);

            Assert.AreEqual(requestUrl4, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoAvailabilityAndPriceWithTypeAndElkoCodesUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string availabilityAndPriceUrl = "/v3.0/api/Catalog/AvailabilityAndPrice/{type}";
            string requestUrl1 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/Availability?elkoCodes=123,456";
            string requestUrl2 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/AvailabilityIncoming?elkoCodes=123,456";
            string requestUrl3 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/AvailabilityIncomingPrice?elkoCodes=123,456";
            string requestUrl4 = "https://api.elkogroup.com/v3.0/api/Catalog/AvailabilityAndPrice/AvailabilityPrice?elkoCodes=123,456";

            // act and assert

            var elko1 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl)
                .WithType(ElkoType.Availability).WithElkoCodes("123", "456");

            Assert.AreEqual(requestUrl1, FluentElkoService.RequestUrl);

            var elko2 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl)
                .WithType(ElkoType.AvailabilityIncoming).WithElkoCodes("123", "456");

            Assert.AreEqual(requestUrl2, FluentElkoService.RequestUrl);

            var elko3 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl)
                .WithType(ElkoType.AvailabilityIncomingPrice).WithElkoCodes("123", "456"); ;

            Assert.AreEqual(requestUrl3, FluentElkoService.RequestUrl);

            var elko4 = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Catalogs().AvailabilityAndPrice(availabilityAndPriceUrl)
                .WithType(ElkoType.AvailabilityPrice).WithElkoCodes("123", "456"); ;

            Assert.AreEqual(requestUrl4, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoInvoiceUrlTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string invoiceUrl = "/v3.0/api/Finances/Invoices/";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Finances/Invoices/";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Finances().Invoices(invoiceUrl);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoInvoiceUrlWithAdditionalInfoTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string invoiceUrl = "/v3.0/api/Finances/Invoices/";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Finances/Invoices/false";

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Finances().Invoices(invoiceUrl).WithAdditionalInfo(false);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }

        [TestMethod]
        public void ElkoInvoiceUrlWithDateRangeTest()
        {
            // arrange
            string baseUrl = "https://api.elkogroup.com";
            string tokenUrl = "/v3.0/api/Token";
            string invoiceUrl = "/v3.0/api/Finances/Invoices/";
            string requestUrl = "https://api.elkogroup.com/v3.0/api/Finances/Invoices/118269/118276";

            var dateFrom = new DateTime(2018, 9, 26);
            var dateTo = new DateTime(2018, 10, 3);

            // act

            var elko = FluentElkoService.WithLogin("username", "password")
                .Api(baseUrl).WithTokenUrl(tokenUrl).Finances().Invoices(invoiceUrl).WithDateRange(dateFrom, dateTo);

            //assert

            Assert.AreEqual(requestUrl, FluentElkoService.RequestUrl);
        }
    }
}
