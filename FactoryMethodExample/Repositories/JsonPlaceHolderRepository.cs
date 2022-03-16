using FactoryMethodExample.ConcreteCreator.JsonPlaceHolder;
using FactoryMethodExample.Creator.ApiClient;
using FactoryMethodExample.Product.ApiClient;
using FactoryMethodExample.Responses.JsonPlaceHolder;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FactoryMethodExample.Repositories
{
    class JsonPlaceHolderRepository
    {
        public JsonPlaceHolderRepository() { }

        public async Task<PostResponse> FindById(int id)
        {
            ApiClientFactory jsonPlaceHolderFactory = new JsonPlaceHolderApiFactory();

            string endpoint = $"posts/{id}";
            string method = "get";

            GenericClientApi genericClient = new GenericClientApi(jsonPlaceHolderFactory, null, endpoint, method, false, null);
            HttpResponseMessage response = await genericClient.Client();

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
