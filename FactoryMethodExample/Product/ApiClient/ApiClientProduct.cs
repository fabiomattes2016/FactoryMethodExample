namespace FactoryMethodExample.Product.ApiClient
{
    public abstract class ApiClientProduct
    {
        public abstract string BaseUrl { get; set; }
        public abstract string HeaderType { get; set; }
    }
}
