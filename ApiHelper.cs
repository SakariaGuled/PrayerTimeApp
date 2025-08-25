using Microsoft.AspNetCore.Identity;
using PrayerTimeApp.Apidata;
using System.Text.Json;

namespace PrayerTimeApp
{
    public class ApiHelper
    {
       
            private readonly HttpClient _client;

            // Constructor takes IHttpClientFactory from DI
            public ApiHelper(IHttpClientFactory httpClientFactory)
            {
                _client = httpClientFactory.CreateClient("PrayerTimeApi");
            }

            // Example method to GET data from an API
            public async Task<string> GetDataAsync(string url)
            {
                var response = await _client.GetAsync(url);
             
                response.EnsureSuccessStatusCode();
                
                return await response.Content.ReadAsStringAsync();
            }
     }
}
