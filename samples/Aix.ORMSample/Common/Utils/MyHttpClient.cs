using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Aix.ORMSample.Common.Utils
{
    public class MyHttpClient
    {
        private static HttpClient Client;

        public static MyHttpClient Instance = new MyHttpClient();
        static MyHttpClient()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };

            //handler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true;
            //   System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //或者
            // handler.ClientCertificateOptions = ClientCertificateOption.Automatic;
            Client = new HttpClient(handler);
        }

        private MyHttpClient() { }

        private HttpClient CreateClient()
        {
            return Client;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            return await CreateClient().SendAsync(httpRequestMessage);
        }

        #region get

        public Task<T> GetAsync<T>(string url)
        {
            return GetAsync<T>(url, null, null);
        }
        public async Task<T> GetAsync<T>(string url, object requestParams, IDictionary<string, string> headers = null)
        {

            url = AddUrlParams(url, requestParams);
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            AddHead(httpRequestMessage, headers);

            var response = await CreateClient().SendAsync(httpRequestMessage);
            if (typeof(T) == typeof(byte[]))
            {
                var bytes = await response.Content.ReadAsByteArrayAsync();
                return (T)Convert.ChangeType(bytes, typeof(T));
            }

            return FromJson<T>(await response.Content.ReadAsStringAsync());
        }

        #endregion

        #region post

        private async Task<HttpResponseMessage> SendAsync(string url, HttpMethod httpMethod, HttpContent httpContent, IDictionary<string, string> headers)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, url);
            httpRequestMessage.Content = httpContent;
            AddHead(httpRequestMessage, headers);
            return await CreateClient().SendAsync(httpRequestMessage);
        }

        //public async Task<string> PostStringAsync(string url, HttpContent httpContent, IDictionary<string, string> headers)
        //{
        //    var response = await SendAsync(url, HttpMethod.Post, httpContent, headers);
        //    return await response.Content.ReadAsStringAsync();
        //}

        public async Task<T> PostAsync<T>(string url, HttpContent httpContent, IDictionary<string, string> headers = null)
        {
            var response = await SendAsync(url, HttpMethod.Post, httpContent, headers);
            if (typeof(T) == typeof(byte[]))
            {
                var bytes = await response.Content.ReadAsByteArrayAsync();
                return (T)Convert.ChangeType(bytes, typeof(T));
            }

            return FromJson<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> DoPostJsonAsync<T>(string url, object requestParams, IDictionary<string, string> headers = null)
        {
            string requestString = ToJson(WebUtils.ToKeyValuePairs(requestParams));
            var httpContent = new StringContent(requestString, Encoding.UTF8, "application/json");
            //var httpContent = new StringContent(requestString, Encoding.UTF8);
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");//application/json; charset=UTF-8
            return await PostAsync<T>(url, httpContent, headers);
        }

        public async Task<T> DoPostUrlEncodedAsync<T>(string url, object requestParams, IDictionary<string, string> headers = null)
        {
            var keyValues = WebUtils.ToKeyValuePairs(requestParams);
            IDictionary<string, string> encodedParms = new Dictionary<string, string>();
            foreach (var item in keyValues)
            {
                encodedParms.Add(item.Key, item.Value?.ToString());
            }
            var content = new FormUrlEncodedContent(encodedParms);
            //等价于

            //var body = WebUtils.BuildQuery(keyValues,false);
            //var content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");
            //ByteArrayContent
            return await PostAsync<T>(url, content, headers);
        }

        #endregion

        #region private 

        private HttpRequestMessage AddHead(HttpRequestMessage httpRequestMessage, IDictionary<string, string> headers)
        {
            if (headers == null) return httpRequestMessage;

            foreach (var item in headers)
            {
                httpRequestMessage.Headers.Add(item.Key, item.Value);
            }
            return httpRequestMessage;
        }

        protected string DictToStr(IEnumerable<KeyValuePair<string, object>> dict, string str_join, bool isUrlEncode)
        {
            if (dict == null || dict.Count() == 0) return string.Empty;

            str_join = str_join == null ? "&" : str_join;
            StringBuilder result = new StringBuilder();
            object value;
            int i = 0;
            foreach (KeyValuePair<string, object> kv in dict)
            {
                value = isUrlEncode == true ? HttpUtility.UrlEncode(kv.Value?.ToString() ?? "", Encoding.UTF8) : kv.Value; // Uri.EscapeDataString  HttpUtility.UrlEncode(kv.Value, Encoding.UTF8)
                result.AppendFormat("{0}{1}={2}", i > 0 ? str_join : "", kv.Key, value);
                i++;
            }
            return result.ToString();

        }

        private string AddUrlParams(string url, object requestParams)
        {
            if (requestParams == null) return url;
            string query = "";
            if (requestParams is string)
            {
                query = requestParams.ToString();
            }
            else
            {
                var keyValues = WebUtils.ToKeyValuePairs(requestParams);
                query = DictToStr(keyValues, "&", true);
            }

            if (url.IndexOf("?") > 0)
            {
                url = url + '&' + query;
            }
            else
            {
                url = url + '?' + query;
            }
            return url;
        }

        private T FromJson<T>(string value)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            return JsonUtils.FromJson<T>(value);
        }

        private string ToJson(object value)
        {
            return JsonUtils.ToJson(value);
        }
        #endregion
    }
}
