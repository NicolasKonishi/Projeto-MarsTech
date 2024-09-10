using PIM_Web.Models;

namespace PIM_Web.Services
{
    public class VisitanteAPI
    {
        private readonly HttpClient _httpClient;
        public VisitanteAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }
   
    }
}
