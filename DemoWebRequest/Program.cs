using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoWebRequest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parallel.For(0, 100, (i) => {
                
                var result = Get("http://www.oschina.net/news/91195/ant-design-3-0-0",30300);
            });
            Console.ReadKey();
        }



        public static string Get(string url, int timeout) 
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.Proxy = null;
            httpWebRequest.Timeout = timeout;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
           // var bytes = Encoding.UTF8.GetBytes(request);
            Stream requestStream = null;
            var responseContent = string.Empty;
            requestStream = httpWebRequest.GetRequestStream();
            //requestStream.Write(bytes, 0, bytes.Length);
            var webResponse = httpWebRequest.GetResponse();
            var stream = webResponse.GetResponseStream();
            if (stream != null)
            {
                var streamReader = new StreamReader(stream);
                responseContent = streamReader.ReadToEnd();
                streamReader.Close();
            }

            webResponse.Close();
            return responseContent;
        }

        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="url">Api地址</param>
        /// <returns></returns>
        public static string GetResponse(string url)
        {
            var result = string.Empty;

            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }
    }
}
