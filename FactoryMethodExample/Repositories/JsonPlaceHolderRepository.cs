using FactoryMethodExample.ConcreteCreator.JsonPlaceHolder;
using FactoryMethodExample.Creator.ApiClient;
using FactoryMethodExample.Product.ApiClient;
using FactoryMethodExample.Responses.JsonPlaceHolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodExample.Repositories
{
    class JsonPlaceHolderRepository
    {
        public JsonPlaceHolderRepository() { }

        public async Task<PostResponse> FindById(int id)
        {
            string baseUrl;
            string headerType;

            ApiClientFactory clientApiFactory = new JsonPlaceHolderApiFactory();
            ApiClientProduct jsonPlaceHolderApiFactory = clientApiFactory.Conexao();

            baseUrl = jsonPlaceHolderApiFactory.BaseUrl;
            headerType = jsonPlaceHolderApiFactory.HeaderType;

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(headerType)
            );

            HttpResponseMessage response = await cliente.GetAsync($"posts/{id}");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                var post = JsonConvert.DeserializeObject<PostResponse>(dados);

                return post;
            }

            return new PostResponse();
        }
    }
}
