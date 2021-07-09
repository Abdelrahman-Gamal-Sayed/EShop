using EShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.DataLayer.Repositories
{
    public interface IOrderRepository
    {
        public Order Add(Order order);
        public Order Delete(int id);
        public IEnumerable<Order> GetAllProduct();
        public Order GetProductByID(int id);
        public Order Update(Order OrderChanges);
    }
}
