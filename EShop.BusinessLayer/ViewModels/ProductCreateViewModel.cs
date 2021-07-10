using EShop.DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EShop.BusinessLayer.ViewModels
{
    public class ProductCreateViewModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Category? Category { get; set; }
        public IFormFile Photo { get; set; }
    }

    public enum categories
    {
        TVs,
        Laptops,
        SoundSystems

    };
}
