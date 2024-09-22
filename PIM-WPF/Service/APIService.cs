using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PIM_WPF.Service
{
    class APIService
    {
        private readonly HttpClient _httpClient;

        public APIService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net");
        }

        public async Task<bool> EnviarDadosAsync<T>(T dados)
        {
            var json = JsonConvert.SerializeObject(dados);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/questionario", content); // Use o caminho correto do endpoint

            return response.IsSuccessStatusCode;
        }
    }
}
