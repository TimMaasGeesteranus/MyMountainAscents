using MyMountainAscents.UWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyMountainAscents.UWP.Services
{
    public class DataService
    {
        public async Task<List<Mountain>> GetAllMountains()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using (var client = new HttpClient(handler))
            {
                //client.BaseAddress = new Uri("https://localhost:44341/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("https://localhost:44341/api/mountain");
                string httpResponseBody = "";
                if (response.IsSuccessStatusCode)
                {
                    httpResponseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Mountain>>(httpResponseBody);
                    return result;
                }
                else
                    return null;
            }
        }

        public async Task<Mountain> GetMountain(Guid guid)
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using (var client = new HttpClient(handler))
            {
                //client.BaseAddress = new Uri("https://localhost:44341/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44341/api/mountain/{guid}");
                string httpResponseBody = "";
                if (response.IsSuccessStatusCode)
                {
                    httpResponseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Mountain>(httpResponseBody);
                    return result;
                }
                else
                    return null;
            }
        }

        public async Task<Mountain> AddMountain(Mountain mountain)
        {
            var content = new StringContent(JsonConvert.SerializeObject(mountain), Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync("https://localhost:44341/api/mountain", content);
                string httpResponseBody = "";
                if (response.IsSuccessStatusCode)
                {
                    httpResponseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Mountain>(httpResponseBody);
                    return result;
                }
                else
                    return null;
            }
        }

        public async Task<Ascent> AddAscent(Ascent ascent, Guid guid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(ascent), Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync($"https://localhost:44341/api/ascent/{guid}", content);
                string httpResponseBody = "";
                if (response.IsSuccessStatusCode)
                {
                    httpResponseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Ascent>(httpResponseBody);
                    return result;
                }
                else
                    return null;
            }
        }

        public async Task<Ascent> DeleteAscent(Guid guid)
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44341/api/ascent/{guid}");
                string httpResponseBody = "";
                if (response.IsSuccessStatusCode)
                {
                    httpResponseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Ascent>(httpResponseBody);
                    return result;
                }
                else
                    return null;
            }
        }
    }
}
