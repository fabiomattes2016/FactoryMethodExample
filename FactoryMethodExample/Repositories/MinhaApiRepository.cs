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
            ApiClientFactory minhaApiFactory = new MinhaApiFactory();

            string endpoint = "auth/local/signin";
            object body = new { email, password };
            string method = "post";

            GenericClientApi genericClient = new GenericClientApi(minhaApiFactory, body, endpoint, method, false, null);
            HttpResponseMessage response = await genericClient.Client();

            if (response.IsSuccessStatusCode)
            {
                TokenResponse tokens = new TokenResponse();
                string dados = await response.Content.ReadAsStringAsync();
                TokenResponse deserializado = JsonConvert.DeserializeObject<TokenResponse>(dados);

                tokens.access_token = deserializado.access_token;
                tokens.refresh_token = deserializado.refresh_token;

                return tokens;
            }

            return new TokenResponse();
        }
    }
}
