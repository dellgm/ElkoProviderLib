using ElkoProvider.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace ElkoProvider
{
    public class FluentElkoService : IElkoLogin, IElkoBaseUrl, IElkoApi, IElkoAvailabilityAndPriceType, IElkoCatalogs, IElkoFinances, IElkoProducts, IElkoInvoices, IElkoInvoicesWith, IElkoCategories, IElkoVendors, IElkoProductDescription, IElkoProductDescriptionWithElkoCode, IElkoAvailabilityAndPriceWithElkoCodes, IElkoAvailabilityAndPrice
    {
        #region Private fields

        private readonly string _username;
        private readonly string _password;

        public static string RequestUrl { get; private set; }
        public static string RequestTokenUrl { get; private set; }
        public static string BearerToken { get; private set; }
        public static string BaseUrl { get; private set; }

        #endregion

        #region Private constructor

        private FluentElkoService(string username, string password)
        {
            _username = username;
            _password = password;
        }

        #endregion

        #region Instantiating method
        public static IElkoLogin WithLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(username);
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(password);

            return new FluentElkoService(username, password);
        }

        #endregion

        #region Chaining methods

        public IElkoBaseUrl Api(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl)) throw new ArgumentNullException(baseUrl);

            BaseUrl = baseUrl;

            return this;
        }

        public IElkoApi WithTokenUrl(string tokenUrl)
        {
            if (string.IsNullOrEmpty(tokenUrl)) throw new ArgumentNullException(tokenUrl);

            RequestTokenUrl = BaseUrl + tokenUrl;

            return this;
        }

        public IElkoCatalogs Catalogs()
        {
            return this;
        }

        public IElkoFinances Finances()
        {
            return this;
        }

        public IElkoCategories Categories(string categoriesUrl)
        {
            if (string.IsNullOrEmpty(categoriesUrl)) throw new ArgumentNullException(categoriesUrl);

            RequestUrl = string.Empty;
            RequestUrl = BaseUrl + categoriesUrl;

            return this;
        }

        public IElkoVendors Vendors(string vendorsUrl)
        {
            if (string.IsNullOrEmpty(vendorsUrl)) throw new ArgumentNullException(vendorsUrl);

            RequestUrl = string.Empty;
            RequestUrl = BaseUrl + vendorsUrl;

            return this;
        }

        public IElkoProductDescription ProductDescription(string productDescriptionUrl)
        {
            if (string.IsNullOrEmpty(productDescriptionUrl)) throw new ArgumentNullException(productDescriptionUrl);

            RequestUrl = string.Empty;
            RequestUrl = BaseUrl + productDescriptionUrl;

            return this;
        }

        public IElkoProductDescriptionWithElkoCode WithElkoCode(string elkoCode)
        {
            if (string.IsNullOrEmpty(elkoCode)) throw new ArgumentNullException(elkoCode);

            RequestUrl = RequestUrl.Replace("{elkoCode}", elkoCode);

            return this;
        }

        public IElkoProducts Products(string productsUrl)
        {
            if (string.IsNullOrEmpty(productsUrl)) throw new ArgumentNullException(productsUrl);

            RequestUrl = string.Empty;
            RequestUrl = BaseUrl + productsUrl;

            return this;
        }

        public IElkoProducts WithCatalogCodes(params string[] catalogCodes)
        {
            if (catalogCodes.Length == 0) throw new ArgumentNullException(catalogCodes.ToString());

            RequestUrl = RequestUrl + MakeUrlString("catalog", catalogCodes);

            return this;
        }

        public IElkoProducts WithVendorCodes(params string[] vendorCodes)
        {
            if (vendorCodes.Length == 0) throw new ArgumentNullException(vendorCodes.ToString());

            RequestUrl = RequestUrl + MakeUrlString("vendorCode", vendorCodes);

            return this;
        }

        public IElkoProducts WithElkoCodes(params string[] elkoCodes)
        {
            if (elkoCodes.Length == 0) throw new ArgumentNullException(elkoCodes.ToString());

            RequestUrl = RequestUrl + MakeUrlString("elkoCode", elkoCodes);

            return this;
        }
        public IElkoAvailabilityAndPriceType AvailabilityAndPrice(string availabilityAndPriceUrl)
        {
            RequestUrl = string.Empty;
            RequestUrl = BaseUrl + availabilityAndPriceUrl;

            return this;
        }

        public IElkoAvailabilityAndPriceWithElkoCodes WithType(ElkoType type)
        {
            RequestUrl = RequestUrl.Replace("{type}", type.ToString());

            return this;
        }

        IElkoAvailabilityAndPrice IElkoAvailabilityAndPriceWithElkoCodes.WithElkoCodes(params string[] elkoCodes)
        {
            if (elkoCodes.Length == 0) throw new ArgumentNullException(elkoCodes.ToString());

            RequestUrl = RequestUrl + MakeUrlString("elkoCodes", elkoCodes);

            return this;
        }

        public IElkoInvoicesWith Invoices(string invoiceUrl)
        {
            RequestUrl = string.Empty;
            RequestUrl = BaseUrl + invoiceUrl;

            return this;
        }

        public IElkoInvoices WithAdditionalInfo(bool withAdditionalInfo)
        {
            RequestUrl = RequestUrl + withAdditionalInfo.ToString().ToLower();

            return this;
        }

        public IElkoInvoices WithDateRange(DateTime dateFrom, DateTime dateTo)
        {
            RequestUrl = RequestUrl + ToElkoDate(dateFrom) + "/" + ToElkoDate(dateTo);

            return this;
        }

        private TResult CallBack<TResult>(Func<FluentElkoService, TResult> func)
        {
            if (string.IsNullOrEmpty(BearerToken))
            {
                BearerToken = Post(new { username = _username, password = _password });
            }

            return func(this);
        }

        private string ToElkoDate(DateTime dateTime)
        {
            var nowCenturyCode = (dateTime.Year / 100) - 19;
            var nowYear = (dateTime.Year % 100);
            var nowDayInYear = dateTime.DayOfYear;
            return string.Format("{0}{1}{2}", nowCenturyCode, nowYear.ToString("00"), nowDayInYear.ToString("000"));
        }

        #endregion

        #region Executing methods

        IEnumerable<ElkoProductDescription> IElkoProductDescriptionWithElkoCode.Get()
        {
            return CallBack(x => x.SendRequest<List<ElkoProductDescription>>());
        }

        IEnumerable<ElkoVendor> IElkoVendors.Get()
        {
            return CallBack(x => x.SendRequest<List<ElkoVendor>>());
        }

        IEnumerable<ElkoCategory> IElkoCategories.Get()
        {
            return CallBack(x => x.SendRequest<List<ElkoCategory>>());
        }

        IEnumerable<ElkoInvoice> IElkoInvoices.Get()
        {
            return CallBack(x => x.SendRequest<List<ElkoInvoice>>());
        }

        IEnumerable<ElkoProduct> IElkoProducts.Get()
        {
            return CallBack(x => x.SendRequest<List<ElkoProduct>>());
        }

        IEnumerable<ElkoAvailabilityAndPrice> IElkoAvailabilityAndPrice.Get()
        {
            return CallBack(x => x.SendRequest<List<ElkoAvailabilityAndPrice>>());
        }

        #endregion

        #region Private methods
        private string Post(object jsonObject)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RequestTokenUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Post;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string jsonString = new JavaScriptSerializer().Serialize(jsonObject);

                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    return result.Replace("\"", "");
                }
            }
        }

        private TResult SendRequest<TResult>()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(RequestUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + BearerToken);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.Timeout = 900000;

            using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var json = new JavaScriptSerializer();
                    json.MaxJsonLength = int.MaxValue;

                    return json.Deserialize<TResult>(result);
                }
            }
        }

        private string MakeUrlString(string tagValue, string[] values)
        {
            var sb = new StringBuilder();
            sb.Append("?");
            sb.Append(tagValue);
            sb.Append("=");
            sb.Append(string.Join(",", values));

            return sb.ToString();
        }

        #endregion
    }

    #region Interfaces

    public interface IElkoLogin
    {
        IElkoBaseUrl Api(string baseUrl);
    }

    public interface IElkoBaseUrl
    {
        IElkoApi WithTokenUrl(string tokenUrl);
    }

    public interface IElkoCatalogs
    {
        IElkoCategories Categories(string categoriesUrl);
        IElkoVendors Vendors(string vendorsUrl);
        IElkoProductDescription ProductDescription(string productDescriptionUrl);
        IElkoProducts Products(string productsUrl);
        IElkoAvailabilityAndPriceType AvailabilityAndPrice(string availabilityAndPriceUrl);
    }

    public interface IElkoFinances
    {
        IElkoInvoicesWith Invoices(string invoiceUrl);
    }

    public interface IElkoInvoicesWith
    {
        IElkoInvoices WithAdditionalInfo(bool withAdditionalInfo);
        IElkoInvoices WithDateRange(DateTime dateFrom, DateTime dateTo);
    }

    public interface IElkoInvoices
    {
        IEnumerable<ElkoInvoice> Get();
    }

    public interface IElkoCategories
    {
        IEnumerable<ElkoCategory> Get();
    }

    public interface IElkoVendors
    {
        IEnumerable<ElkoVendor> Get();
    }

    public interface IElkoProductDescription
    {
        IElkoProductDescriptionWithElkoCode WithElkoCode(string elkoCode);
    }

    public interface IElkoProductDescriptionWithElkoCode
    {
        IEnumerable<ElkoProductDescription> Get();
    }

    public interface IElkoProducts
    {
        IElkoProducts WithCatalogCodes(params string[] catalogCodes);
        IElkoProducts WithVendorCodes(params string[] vendorCodes);
        IElkoProducts WithElkoCodes(params string[] elkoCodes);
        IEnumerable<ElkoProduct> Get();
    }

    public interface IElkoApi
    {
        IElkoCatalogs Catalogs();
        IElkoFinances Finances();
    }

    public interface IElkoAvailabilityAndPriceType
    {
        IElkoAvailabilityAndPriceWithElkoCodes WithType(ElkoType type);
    }

    public interface IElkoAvailabilityAndPriceWithElkoCodes
    {
        IElkoAvailabilityAndPrice WithElkoCodes(params string[] elkoCodes);

    }

    public interface IElkoAvailabilityAndPrice
    {
        IEnumerable<ElkoAvailabilityAndPrice> Get();
    }

    #endregion
}
