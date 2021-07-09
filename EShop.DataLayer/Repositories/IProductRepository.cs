using EShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.DataLayer.Repositories
{
    public interface IProductRepository
    {
        public Product Add(Product product);
        public Product Delete(int id);
        public IEnumerable<Product> GetAllProduct();
        public Product GetProductByID(int id);
        public Product Update(Product productChanges);

    }
}
