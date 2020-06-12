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
    public class FoodTypeController : Controller
    {
      private readonly IFoodTypeService _foodService;
        public FoodTypeController(IFoodTypeService foodService)
        {
            _foodService = foodService;
        }

        [BindProperty]
        public FoodType FoodType { get; set; }

        public IActionResult ListFoodType()
        {
            return View();
        }
                
        [HttpGet]
        public IEnumerable<FoodType> GetAll()
        {
            return _foodService.ListAllFoodTypes();
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            FoodType = new FoodType();
            if (id == null || id == 0)
            {
                return View(FoodType);
            }
            FoodType = _foodService.FindFoodType(id);
            if (FoodType == null)
            {
                return NotFound();
            }
          return View(FoodType);
            //return View("Upsert");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            int status;
            if (ModelState.IsValid)
            {
               status = _foodService.SaveFoodType(FoodType);
                return RedirectToAction("ListFoodType");
            }
            return View("Upsert");
        }



        //[HttpGet]
        //public IEnumerable<FoodType> GetAll()
        //{
        //    return FoodTypeService.ListAllFoodTypes();
        //}


        [HttpGet]
        public IActionResult Delete(int id)
        {
            FoodType = new FoodType();
            FoodType = _foodService.FindFoodType(id);
            if (FoodType == null)
            {

                return RedirectToAction("ListFoodType");
                //  return Json(new { success = false, message = "Error while Deleting" });
            }
            else
            {
                _foodService.DeleteFoodType(FoodType);
                return RedirectToAction("ListFoodType");
                // return Json(new { success = true, message = "Delete Successful" });
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}