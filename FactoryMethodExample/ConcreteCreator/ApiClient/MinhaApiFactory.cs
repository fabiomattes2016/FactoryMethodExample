using FactoryMethodExample.ConcreteProduct.ApiClient;
using FactoryMethodExample.Creator.ApiClient;
using FactoryMethodExample.Product.ApiClient;

namespace FactoryMethodExample.ConcreteCreator.ApiClient
{
    public class MinhaApiFactory : ApiClientFactory
    {
        private string _baseUrl;
        private string _headerType;

        public MinhaApiFactory(
            string baseUrl = "http://localhost:3333/",
            string headerType = "application/json"
        )
        {
            this._baseUrl = baseUrl;
            this._headerType = headerType;
        }

        public override ApiClientProduct Conexao()
        {
            return new ApiClientConcret(_baseUrl, _headerType);
        }
    }
}
