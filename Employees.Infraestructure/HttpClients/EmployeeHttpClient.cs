using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infraestucture.HttpClients
{
    public class EmployeeHttpClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            var data = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(data);

            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
