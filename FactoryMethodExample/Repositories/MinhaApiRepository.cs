using FactoryMethodExample.ConcreteCreator.ApiClient;
using FactoryMethodExample.Creator.ApiClient;
using FactoryMethodExample.Models;
using FactoryMethodExample.Product.ApiClient;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodExample.Repositories
{
    public class MinhaApiRepository
    {
        public MinhaApiRepository()
        { }

        public async Task<TokenResponse> LoginAsync(string email, string password)
        {
            string baseUrl;
            string headerType;

            ApiClientFactory clientApiFactory = new MinhaApiFactory();
            ApiClientProduct minhaApiFactory = clientApiFactory.Conexao();

            baseUrl = minhaApiFactory.BaseUrl;
            headerType = minhaApiFactory.HeaderType;

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(headerType)
            );

            var body = new { email, password };
            var jsonContent = JsonConvert.SerializeObject(body);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, minhaApiFactory.HeaderType);

            HttpResponseMessage response = await cliente.PostAsync("auth/local/signin", contentString);

            if (response.IsSuccessStatusCode)
            {
                var tokens = new TokenResponse();
                var dados = await response.Content.ReadAsStringAsync();
                var deserializado = JsonConvert.DeserializeObject<TokenResponse>(dados);

                tokens.access_token = deserializado.access_token;
                tokens.refresh_token = deserializado.refresh_token;

                return tokens;
            }

            return new TokenResponse();
        }
    }
}
