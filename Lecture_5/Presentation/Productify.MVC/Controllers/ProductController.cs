using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Productify.Domain.Entities;
using Productify.Persistance.Contexts;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productify.MVC.Controllers
{
    public class ProductController : Controller
    {

        //        List<Product>_products = new()
        //   {
        //       new Product("Laptop Computer"),
        //       new Product("Smartphone"),
        //       new Product("Wireless Headphones"),
        //       new Product("Digital Camera"),
        //       new Product("Tablet")
        //   };


        ProductifyDbContext _context;

        public ProductController()
        {
            _context = new ProductifyDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(_context.Products.ToList());
        }

       
        [HttpPost]
        public IActionResult GetAll(string ProductName)
        {
            _context.Products.Add(new Product(ProductName));
            _context.SaveChanges();
            return View(_context.Products.ToList());
        }

        [HttpPost]
        public IActionResult DeleteProduct(Guid id)
        {

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("GetAll");
        }

    }
}

