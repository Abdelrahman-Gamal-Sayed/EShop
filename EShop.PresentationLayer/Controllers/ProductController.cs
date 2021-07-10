using EShop.BusinessLayer.ViewModels;
using EShop.DataLayer.Models;
using EShop.DataLayer.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ProductController(IProductRepository productRepository,
                              IWebHostEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productRepository.GetAllProduct());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
           var Product= _productRepository.GetProductByID(id);
            ProductDetailsVM productDetailsVM = new ProductDetailsVM
            {
                Id = Product.Id,
                Name = Product.Name,
                CategoryId = Product.CategoryId,
                CategoryName = Product.Category?.Name,
                Description = Product.Description,
                Price = Product.Price
            };
            return View(productDetailsVM);
        }

        // GET: ProductController/Create
        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {


                Product product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.Category.Id,
                    Price = model.Price,
                };

                _productRepository.Add(product);
                string uniqueFileName = ProcessUplodedFile(model, product.Id);
                return RedirectToAction("details", new { id = product.Id });
            }

            return View();
        }
        private string ProcessUplodedFile(ProductCreateViewModel model,int id)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
      
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                uniqueFileName = id.ToString();
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
      
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }
        // POST: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
