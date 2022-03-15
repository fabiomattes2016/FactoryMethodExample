using FactoryMethodExample.Product.ApiClient;

namespace FactoryMethodExample.ConcreteProduct.ApiClient
{
    public class ApiClientConcret : Product.ApiClient.ApiClientProduct
    {
        private string _baseUrl;
        private string _headerType;

        public ApiClientConcret(
            string baseUrl,
            string headerType
        )
        {
            this._baseUrl = baseUrl;
            this._headerType = headerType;
        }

        public override string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        public override string HeaderType {
            get { return _headerType; }
            set { _headerType = value; }
        }
    }
}
