using Easy.Commerce.WebApi.Data;
using Easy.Commerce.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy.Commerce.WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool Delete(int productID)
        {
            appDbContext.Products.Remove(new Product { ProductID = productID });
            appDbContext.SaveChanges();
            return true;
        }

        public bool Exist(int productID)
        {
            return appDbContext.Products.Any(p => p.ProductID == productID);
        }

        public IList<Product> Get()
        {
            return appDbContext.Products.Include(c => c.Category).ToList();
        }

        public Product GetById(int productID)
        {
            return appDbContext.Products.FirstOrDefault(p => p.ProductID == productID);
        }

        public Product Save(Product product)
        {
            if (product.ProductID > 0)
            {
                var productFromDb = appDbContext.Products.AsNoTracking().Any(x => x.ProductID == product.ProductID);
                if (productFromDb)
                {
                    product.ModifiedDate = DateTime.UtcNow;
                    appDbContext.Entry<Product>(product).State = EntityState.Modified;
                }
            }
            if (product.ProductID == 0)
            {
                product.CreatedDate = product.ModifiedDate = DateTime.UtcNow;
                appDbContext.Entry<Product>(product).State = EntityState.Added;

            }
            appDbContext.SaveChanges();
            return product;
        }
    }
}
