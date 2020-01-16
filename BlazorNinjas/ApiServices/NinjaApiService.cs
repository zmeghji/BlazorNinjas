using ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorNinjas.ApiServices
{
    public interface INinjaApiService
    {
        Task<List<NinjaApiModel>> Get();
    }
    public class NinjaApiService: INinjaApiService
    {
        private readonly HttpClient _httpClient;

        public NinjaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NinjaApiModel>> Get()
        {
            var resp = await _httpClient.GetAsync("ninjas");
            var stringContent = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<NinjaApiModel>>(stringContent);
        }
    }
}
