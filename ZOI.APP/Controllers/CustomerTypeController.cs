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
    public class CustomerTypeController : Controller
    {
      private readonly ICustomerTypeService _CustomerTypeService;

        public CustomerTypeController(ICustomerTypeService CustomerTypeService)
        {
            _CustomerTypeService = CustomerTypeService;
        }

        [BindProperty]
        public CustomerType CustomerType { get; set; }

        public IActionResult ListCustomerType()
        {
            return View();
        }
                
        [HttpGet]
        public IEnumerable<CustomerType> GetAll()
        {
            return _CustomerTypeService.ListAllCustomerTypes();
        }


        //   [HttpGet]
        //   public IActionResult Upsert(int? id)
        public IActionResult Upsert(int? id)
        {
            CustomerType = new CustomerType();
            if (id == null || id == 0)
            {
                return View(CustomerType);
            }
            CustomerType = _CustomerTypeService.FindCustomerType(id);
            if (CustomerType == null)
            {
                return NotFound();
            }
          return View(CustomerType);
            //return View("Upsert");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            int status;
            if (ModelState.IsValid)
            {
               status = _CustomerTypeService.SaveCustomerType(CustomerType);
                return RedirectToAction("ListCustomerType");
            }
            return View("Upsert");
        }



        //[HttpGet]
        //public IEnumerable<CustomerType> GetAll()
        //{
        //    return CustomerTypeService.ListAllCustomerTypes();
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CustomerType = new CustomerType();
            CustomerType = _CustomerTypeService.FindCustomerType(id);
            if (CustomerType == null)
            {
                //   return Json(new { success = false, message = "Error while Deleting" });
                return RedirectToAction("ListCustomerType");
            }
            else
            {
                _CustomerTypeService.DeleteCustomerType(CustomerType);
                return RedirectToAction("ListCustomerType");
                // return Json(new { success = true, message = "Delete Successful" });
            }
        }

      
        public IActionResult Index()
        {
            return View();
        }
    }
}