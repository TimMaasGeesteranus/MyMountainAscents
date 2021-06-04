using MyMountainAscents.Data.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp.Serialization;
using System;

namespace MyMountainAscents.UI.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Ascent> AddAscent(Ascent ascent, Guid mountainGuid)
        {
            string jsonString = JsonSerializer.Serialize(ascent);
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44341/api/ascent/{mountainGuid.ToString()}")
            {
                Content = new StringContent(jsonString, Encoding.UTF8, ContentType.Json)
            };

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Ascent>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Mountain> AddMountain(Mountain mountain)
        {
            string jsonString = JsonSerializer.Serialize(mountain);
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44341/api/mountain")
            {
                Content = new StringContent(jsonString, Encoding.UTF8, ContentType.Json)
            };

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Mountain>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Ascent> DeleteAscent(Guid ascentGuid)
        {
            using var response = await _httpClient.DeleteAsync($"https://localhost:44341/api/ascent/{ascentGuid.ToString()}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Ascent>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<Mountain>> GetAllMountains()
        {
            using var response = await _httpClient.GetAsync("https://localhost:44341/api/mountain");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Mountain>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Mountain> GetMountainByGuid(Guid guid)
        {
            using var response = await _httpClient.GetAsync($"https://localhost:44341/api/mountain/{guid}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Mountain>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
