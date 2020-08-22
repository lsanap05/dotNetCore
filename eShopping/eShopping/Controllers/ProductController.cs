using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopping.Models;
using eShopping.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product, int> ProRepo;
        /// <summary>
        /// Inject the Category Repository
        /// </summary>
        public ProductController(IRepository<Product, int> ProRepo)
        {
            this.ProRepo = ProRepo;
        }
        /// <summary>
        /// Http Get methdo to return Index view with List of Categories
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await ProRepo.GetAsync();
            return View(products);
        }

        /// <summary>
        /// Http Get method that will return empty View for accepting Cateogry Data 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var products = new Product();
            return View(products);
        }

        /// <summary>
        /// Http Post method to accept Category data from View request 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Product products)
        {
            // validate the model
            if (ModelState.IsValid)
            {
                products = await ProRepo.CreateAsync(products);
                // return the Index action methods from
                // the current controller
                return RedirectToAction("Index");
            }
            return View(products); // stey on same page and show error messages
        }
        /// <summary>
        /// Get ID and shows category for edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> edit(int id)
        {
            var products = await ProRepo.GetAsync(id);
            return View(products);
        }
        /// <summary>
        ///  http post method to Update Category data from view request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> edit(Product products)
        {
            if (ModelState.IsValid)
            {
                products = await ProRepo.UpdateAsync(Convert.ToInt16(products.ProductId), products);
                // return the Index action methods from
                // the current controller
                return RedirectToAction("Index");
            }
            return View(products);
        }
        /// <summary>
        /// Get ID and shows details of Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var products = await ProRepo.GetAsync(id);
            return View(products);
        }
        /// <summary>
        /// get ID From Main page and Delete The record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var products = await ProRepo.GetAsync(id);
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string ProductId)
        {
            var cats = await ProRepo.DeleteAsync(Convert.ToInt32(ProductId));
            return RedirectToAction("Index");

        }
    }
}
