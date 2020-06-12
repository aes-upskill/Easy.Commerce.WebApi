using Easy.Commerce.WebApi.Models;
using System.Collections.Generic;

namespace Easy.Commerce.WebApi.Services
{
    public interface ICategoryService
    {
        IList<Category> Get();
    }
}
