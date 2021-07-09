using System;
using System.Collections.Generic;

#nullable disable

namespace EShop.DataLayer.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime IssueDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
