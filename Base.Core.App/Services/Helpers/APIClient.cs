using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Base.Core.App.Services.Helpers
{
    public partial class ApiClient
    {

        private readonly HttpClient _httpClient;
        private string BaseEndpoint { get; set; }
        private string _token;

        public ApiClient(string baseEndpoint,string token)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _token = token;
            _httpClient = new HttpClient();
        }

        /// <summary>  
        /// Common method for making GET calls  
        /// </summary>  
        public async Task<T> GetAsync<T>(string requestUrl)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(CreateRequestUri(requestUrl), HttpCompletionOption.ResponseHeadersRead);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>  
        /// Common method for making POST calls  
        /// </summary>  
        public async Task<T> PostAsync<T>(string requestUrl, T content)
        {
            addHeaders();
            var response = await _httpClient.PostAsync(CreateRequestUri(requestUrl), CreateHttpContent<T>(content));
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        public async Task<T1> PostAsync<T1, T2>(string requestUrl, T2 content)
        {

            var response = await _httpClient.PostAsync(CreateRequestUri(requestUrl), CreateHttpContent<T2>(content));
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T1>(data);
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            return new Uri(new Uri(BaseEndpoint), relativePath);
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer "+_token);
        }
    }
}
