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
    public class MenuTimeSlotController : Controller
    {
        private readonly IMenuTimeSlotService _MenuTimeSlotService;

        public MenuTimeSlotController(IMenuTimeSlotService MenuTimeSlotService)
        {
            _MenuTimeSlotService = MenuTimeSlotService;
        }

        [BindProperty]
        public MenuTimeSlot MenuTimeSlot { get; set; }

        public IActionResult ListFoodSlots()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<MenuTimeSlot> GetAll()
        {
            return _MenuTimeSlotService.ListAllMenuTimeSlots();
        }




        public IActionResult Upsert(int? id)
        {
            MenuTimeSlot = new MenuTimeSlot();
            if (id == null || id == 0)
            {
                return View(MenuTimeSlot);
            }
            MenuTimeSlot = _MenuTimeSlotService.FindMenuTimeSlot(id);
            if (MenuTimeSlot == null)
            {
                return NotFound();
            }
            return View(MenuTimeSlot);
            //return View("Upsert");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            int status;
            if (ModelState.IsValid)
            {
                status = _MenuTimeSlotService.SaveMenuTimeSlot(MenuTimeSlot);
                return RedirectToAction("ListFoodSlots");
            }
            return View("Upsert");
        }


        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            MenuTimeSlot = new MenuTimeSlot();
            MenuTimeSlot = _MenuTimeSlotService.FindMenuTimeSlot(id);
            if (MenuTimeSlot == null)
            {
                return RedirectToAction("ListFoodSlots");
                // return Json(new { success = false, message = "Error while Deleting" });
            }
            else
            {
                _MenuTimeSlotService.DeleteMenuTimeSlot(MenuTimeSlot);
                return RedirectToAction("ListFoodSlots");
                //return Json(new { success = true, message = "Delete Successful" });
            }
        }


       




        public IActionResult Index()
        {
            return View();
        }




    }
}
