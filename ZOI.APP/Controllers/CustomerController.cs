using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZOI.BAL.Models;
using ZOI.BAL.DBContext;
using Microsoft.EntityFrameworkCore;
using ZOI.BAL.Services;
using ZOI.DAL.DatabaseUtility;
using ZOI.BAL.Services.Interface;


namespace ZOI.APP.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerService _CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult ListCustomer()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Customer = new Customer();
            if (id == null || id == 0)
            {
                return View(Customer);
            }
            Customer = _CustomerService.FindCustomer(id);
            if (Customer == null)
            {
                return NotFound();
            }
           // return View(Customer);
            return View("Upsert");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            int status;
            if (ModelState.IsValid)
            {
                status = _CustomerService.SaveCustomer(Customer);
                return RedirectToAction("ListCustomer");
            }
            return View("Upsert");
        }



        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _CustomerService.ListAllCustomers();
        }

        [HttpGet]
      //  [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Customer = new Customer();
            Customer = _CustomerService.FindCustomer(id);
            if (Customer == null)
            {
                //   return Json(new { success = false, message = "Error while Deleting" });
                return RedirectToAction("ListCustomer");
            }
            else
            {
                _CustomerService.DeleteCustomer(Customer);

                //  return Json(new { success = true, message = "Delete Successful" });
                return RedirectToAction("ListCustomer");
            }
        }



        public IActionResult ListCustomers()
        {
            return View();
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
