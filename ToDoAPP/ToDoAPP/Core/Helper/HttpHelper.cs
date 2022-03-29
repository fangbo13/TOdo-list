using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ToDoAPP.Common;

namespace ToDoAPP.Core.Helper
{
    public class HttpHelper: SingleSton<HttpHelper>
    {
        public string BaseUrl = "http://192.168.1.150:51609";

        public string Token = "";

        public int requestTimeout = 10;

        public R Request<T, R>(string routeUrl, T param, HttpMethod httpMethod, Action<HttpRequestMessage> beforeAction = null, Action<HttpResponseMessage> afterAction = null)
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 0, requestTimeout);

                var httpRequest = new HttpRequestMessage();
                httpRequest.RequestUri = new Uri(BaseUrl + routeUrl);
                if (!string.IsNullOrWhiteSpace(Token))
                    httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                httpRequest.Content = new StringContent(param != null ? Newtonsoft.Json.JsonConvert.SerializeObject(param) : string.Empty, Encoding.UTF8,
                                   "application/json");
                httpRequest.Method = httpMethod;
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                beforeAction?.Invoke(httpRequest);
                HttpResponseMessage httpResponseMessage = httpClient.SendAsync(httpRequest).Result;
                afterAction?.Invoke(httpResponseMessage);

                if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new HttpRequestException(httpResponseMessage.StatusCode.ToString());
                //throw new HttpRequestException(httpResponseMessage.Result.ToString());
                var resStr = httpResponseMessage.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrWhiteSpace(resStr))
                    return default;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<R>(resStr);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public T Request<T>(string routeUrl, HttpMethod httpMethod, Action<HttpRequestMessage> beforeAction = null, Action<HttpResponseMessage> afterAction = null)
        {
            return Request<string, T>(routeUrl, null, httpMethod, beforeAction, afterAction);
        }
    }
}
