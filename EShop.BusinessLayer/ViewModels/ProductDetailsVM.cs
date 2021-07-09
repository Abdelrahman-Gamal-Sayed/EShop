﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.BusinessLayer.ViewModels
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceAfterDiscount { get; set; }
        public decimal? TwoPiecesPrice { get; set; }

    }
}
