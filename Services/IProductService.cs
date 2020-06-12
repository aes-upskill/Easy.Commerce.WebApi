using Easy.Commerce.WebApi.Models;
using System.Collections.Generic;

namespace Easy.Commerce.WebApi.Services
{
    public interface IProductService
    {
        Product GetById(int productID);
        IList<Product> Get();
        Product Save(Product product);
        bool Delete(int productID);
        bool Exist(int productID);
    }
}
