using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WxService
{
    public class HttpUtil
    {
        /// <summary>
        /// http Get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<String> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return response.StatusCode.ToString();
            }
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            var result = await GetAsync(url);
            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// http Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, string jsondata)
        {
            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(jsondata)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                };
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return response.StatusCode.ToString();
            }
        }

        public static async Task<T> PostAsync<T>(string url, string jsondata)
        {
            var result = await PostAsync(url, jsondata);
            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// http Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public static async Task<String> PostAsync(string url, Object data)
        {
            string jsondata = JsonConvert.SerializeObject(data);
            return await PostAsync(url, data);
        }

        public static async Task<T> PostAsync<T>(string url, Object data)
        {
            var result = await PostAsync(url, data);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}