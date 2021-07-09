using EShop.DataLayer.Models;
using System;
using System.Data;

using System.Collections.Generic;
using System.Text;

namespace EShop.DataLayer.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly AppDBContext Context;

        public SQLProductRepository(AppDBContext appDBContext)
        {
            Context = appDBContext;
        }

        public Product Add(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            Product product = Context.Products.Find(id);
            if (product != null)
            {
                Context.Products.Remove(product);
                Context.SaveChanges();
            }
       
            return product;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return Context.Products;
        }

        public Product GetProductByID(int id)
        {
            return Context.Products.Find(id);
        }

        public Product Update(Product productChanges)
        {
            var product = Context.Products.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return productChanges;
        }

    }
}
