namespace FactoryMethodExample.Product.ApiClient
{
    public abstract class ApiClientProduct
    {
        public abstract string GetBaseUrl();
        public abstract void SetBaseUrl(string value);

        public abstract string GetHeaderType();
        public abstract void SetHeaderType(string value);
    }
}
