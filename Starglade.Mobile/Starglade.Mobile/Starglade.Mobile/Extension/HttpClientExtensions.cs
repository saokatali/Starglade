using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Starglade.Mobile.Extension
{
    public static class HttpClientExtensions
    {
        public static async Task<List<T>> GetAllAsync<T>(this HttpClient httpClient, string url)
        {
            var message = await httpClient.GetAsync(url);

            var data = await message.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<T>>(data,new JsonSerializerOptions { PropertyNameCaseInsensitive=true });
        }

        public static async Task<T> GetByIdAsync<T>(this HttpClient httpClient, string url)
        {
            var message = await httpClient.GetAsync(url);

            var data = await message.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<TResult> PostDataAsync<TContent, TResult>(this HttpClient httpClient, string url, TContent content )
        {
            var requestData = JsonSerializer.Serialize(content);
            var message = await httpClient.PostAsync(url, new StringContent(requestData));

            var data = await message.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }



    }
}
