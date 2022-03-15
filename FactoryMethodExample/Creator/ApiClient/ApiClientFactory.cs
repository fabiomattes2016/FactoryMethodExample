using FactoryMethodExample.Product.ApiClient;

namespace FactoryMethodExample.Creator.ApiClient
{
    public abstract class ApiClientFactory
    {
        public abstract ApiClientProduct Conexao();
    }
}
