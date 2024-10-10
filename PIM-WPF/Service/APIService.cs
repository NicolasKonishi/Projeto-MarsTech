using Newtonsoft.Json;
using PIM_WPF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PIM_WPF.Service
{
    class APIService
    {
        private readonly HttpClient _httpClient;

        public APIService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7195");
        }

        public async Task<bool> EnviarDadosAsync<T>(T dados)
        {
            var json = JsonConvert.SerializeObject(dados);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7195/api/questionario", content); // Use o caminho correto do endpoint

            return response.IsSuccessStatusCode;
        }

        public async Task<decimal> ObterMediaExposicaoAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7195/api/questionario/average-exhibitions");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var mediaExposicao = JsonConvert.DeserializeObject<decimal>(json);
                return mediaExposicao;
            }

            throw new Exception("Erro ao obter média da exposição.");
        }

        public async Task<decimal> ObterMediaQualidadeoAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7195/api/questionario/average-satisfaction");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var mediaExposicao = JsonConvert.DeserializeObject<decimal>(json);
                return mediaExposicao;
            }

            throw new Exception("Erro ao obter média da exposição.");
        }

        public async Task<ComentarioResponse> ObterComentarioAleatorioAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7195/api/questionario/random-comment"); // Utilize o endpoint correto

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var comentarioResponse = JsonConvert.DeserializeObject<ComentarioResponse>(json);
                return comentarioResponse;
            }

            throw new Exception("Erro ao obter comentário.");
        }
    }
}
