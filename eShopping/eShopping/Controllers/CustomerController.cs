using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopping.Models;
using eShopping.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer, int> custRepo;
        /// <summary>
        /// Inject the Customer Repository
        /// </summary>
        public CustomerController(IRepository<Customer, int> CustRepo)
        {
            this.custRepo = CustRepo;
        }
        /// <summary>
        /// Http Get method to return Index view with List of Customer
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var cats = await custRepo.GetAsync();
            return View(cats);
        }

        /// <summary>
        /// Http Get method that will return empty View for accepting Customer Data 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var cat = new Customer();
            return View(cat);
        }

        /// <summary>
        /// Http Post method to accept Customer data from View request 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Customer cat)
        {
            // validate the model
            if (ModelState.IsValid)
            {
                cat = await custRepo.CreateAsync(cat);
                // return the Index action methods from
                // the current controller
                return RedirectToAction("Index");
            }
            return View(cat); // stey on same page and show error messages
        }
        /// <summary>
        /// Get ID and shows Customer for edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> edit(int id)
        {
            var cats = await custRepo.GetAsync(id);
            return View(cats);
        }
        /// <summary>
        ///  http post method to Update Customer data from view request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> edit(Customer cat)
        {
            if (ModelState.IsValid)
            {
                cat = await custRepo.UpdateAsync(Convert.ToInt16(cat.CustomerRowId), cat);
                // return the Index action methods from
                // the current controller
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        /// <summary>
        /// Get ID and shows details of Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var cats = await custRepo.GetAsync(id);
            return View(cats);
        }
        /// <summary>
        /// get ID From Main page and Delete The record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var cats = await custRepo.GetAsync(id);
            return View(cats);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string customerRowID)
        {
            var cats = await custRepo.DeleteAsync(Convert.ToInt32(customerRowID));
            return RedirectToAction("Index");

        }
    }
}
