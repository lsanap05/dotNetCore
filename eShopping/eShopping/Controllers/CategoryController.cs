using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using eShopping.Models;
using eShopping.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eShopping.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category, int> catRepo;
        /// <summary>
        /// Inject the Category Repository
        /// </summary>
        public CategoryController(IRepository<Category, int> catRepo)
        {
            this.catRepo = catRepo;
        }
        /// <summary>
        /// Http Get methdo to return Index view with List of Categories
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var cats = await catRepo.GetAsync();
            return View(cats);
        }

        /// <summary>
        /// Http Get method that will return empty View for accepting Cateogry Data 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var cat = new Category();
            return View(cat);
        }

        /// <summary>
        /// Http Post method to accept Category data from View request 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Category cat)
        {
            // validate the model
            if (ModelState.IsValid)
            {
                cat = await catRepo.CreateAsync(cat);
                // return the Index action methods from
                // the current controller
                return RedirectToAction("Index");
            }
            return View(cat); // stey on same page and show error messages
        }
        /// <summary>
        /// Get ID and shows category for edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> edit(int id)
        {
            var cats = await catRepo.GetAsync(id);
            return View(cats);
        }
        /// <summary>
        ///  http post method to Update Category data from view request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                cat = await catRepo.UpdateAsync(Convert.ToInt16(cat.CategoryId), cat);
                // return the Index action methods from
                // the current controller
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        /// <summary>
        /// Get ID and shows details of Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var cats = await catRepo.GetAsync(id);
            return View(cats);
        }
        /// <summary>
        /// get ID From Main page and Delete The record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var cats = await catRepo.GetAsync(id);
            return View(cats);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string CategoryRowId)
        {
                var cats = await catRepo.DeleteAsync(Convert.ToInt32(CategoryRowId));
                return RedirectToAction("Index");
        
        }
    }
}
