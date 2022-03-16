using FactoryMethodExample.ConcreteProduct.ApiClient;
using FactoryMethodExample.Creator.ApiClient;
using FactoryMethodExample.Product.ApiClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodExample.ConcreteCreator.JsonPlaceHolder
{
    class JsonPlaceHolderApiFactory : ApiClientFactory
    {
        private readonly string _baseUrl;
        private readonly string _headerType;

        public JsonPlaceHolderApiFactory(
            string baseUrl = "https://jsonplaceholder.typicode.com/",
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
