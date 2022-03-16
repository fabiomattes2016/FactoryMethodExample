using FactoryMethodExample.ConcreteProduct.ApiClient;
using FactoryMethodExample.Creator.ApiClient;
using FactoryMethodExample.Product.ApiClient;

namespace FactoryMethodExample.ConcreteCreator.ApiClient
{
    public class MinhaApiFactory : ApiClientFactory
    {
        /*
         * Essa api está disponível em: https://github.com/fabiomattes2016/nestjs-jwt 
         */

        private readonly string _baseUrl;
        private readonly string _headerType;

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
