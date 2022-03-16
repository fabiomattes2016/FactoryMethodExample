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

        public override string GetBaseUrl()
        { return _baseUrl; }

        public override void SetBaseUrl(string value)
        { _baseUrl = value; }

        public override string GetHeaderType()
        { return _headerType; }

        public override void SetHeaderType(string value)
        { _headerType = value; }
    }
}
