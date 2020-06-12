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
    public class MenuDetailController : Controller
    {
        private readonly IMenuDetailService _MenuDetailService;

        public MenuDetailController(IMenuDetailService MenuDetailService)
        {
            _MenuDetailService = MenuDetailService;
        }

        [BindProperty]
        public MenuDetail MenuDetail { get; set; }

        public IActionResult ListMenuDetails()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<MenuDetail> GetAll()
        {
            return _MenuDetailService.ListAllMenuDetails();
        }




        public IActionResult Upsert(int? id)
        {
            MenuDetail = new MenuDetail();
            if (id == null || id == 0)
            {
                return View(MenuDetail);
            }
            MenuDetail = _MenuDetailService.FindMenuDetail(id);
            if (MenuDetail == null)
            {
                return NotFound();
            }
            return View(MenuDetail);
            //return View("Upsert");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            int status;
            if (ModelState.IsValid)
            {
                status = _MenuDetailService.SaveMenuDetail(MenuDetail);
                return RedirectToAction("ListMenuDetail");
            }
            return View("Upsert");
        }


        [HttpGet]
     //   [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            MenuDetail = new MenuDetail();
            MenuDetail = _MenuDetailService.FindMenuDetail(id);
            if (MenuDetail == null)
            {
                return RedirectToAction("ListMenuDetail");
                //  return Json(new { success = false, message = "Error while Deleting" });
            }
            else
            {
                _MenuDetailService.DeleteMenuDetail(MenuDetail);
                return RedirectToAction("ListMenuDetail");
                //   return Json(new { success = true, message = "Delete Successful" });
            }
        }

        public IActionResult ListMenu()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
