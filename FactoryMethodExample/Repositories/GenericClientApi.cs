using FactoryMethodExample.Creator.ApiClient;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodExample.Repositories
{
    public class GenericClientApi
    {
        private ApiClientFactory _apiClientFactory;
        private object _body = null;
        private string _endpoint;
        private string _method;
        private bool _isAuthenticated = false;
        private string _token = null;

        public GenericClientApi(ApiClientFactory apiClientFactory, object body, string endpoint, string method, bool isAuthenticated, string token)
        {
            _apiClientFactory = apiClientFactory;
            _body = body;
            _endpoint = endpoint;
            _method = method;
            _isAuthenticated = isAuthenticated;
            _token = token;
        }

        public async Task<HttpResponseMessage> Client()
        {
            string baseUrl;
            string headerType;

            var clientFactory = _apiClientFactory;
            var apiClientProduct = clientFactory.Conexao();

            baseUrl = apiClientProduct.BaseUrl;
            headerType = apiClientProduct.HeaderType;

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(headerType)
            );

            if (_isAuthenticated)
            {
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            }

            string jsonContent = null;
            StringContent content = null;
            HttpResponseMessage response = null;

            if (_body != null)
            {
               jsonContent = JsonConvert.SerializeObject(_body);
               content = new StringContent(jsonContent, Encoding.UTF8, apiClientProduct.HeaderType);
            }

            switch (_method)
            {
                case "post":
                    response = await cliente.PostAsync($"{_endpoint}", content);
                    break;
                case "get":
                    response = await cliente.GetAsync($"{_endpoint}");
                    break;
                case "put":
                    response = await cliente.PutAsync($"{_endpoint}", content);
                    break;
                case "patch":
                    response = await cliente.PatchAsync($"{_endpoint}", content);
                    break;
                case "delete":
                    response = await cliente.DeleteAsync($"{_endpoint}");
                    break;
                default:
                    break;
            }

            return response;
        }
    }
}
