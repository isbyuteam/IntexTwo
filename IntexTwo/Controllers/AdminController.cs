using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntexTwo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IntexTwo.Models.ViewModels;

namespace IntexTwo.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private CrashesDbContext _context { get; set; }

        public AdminController(CrashesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pageNum = 1)
        {
            var crashes = _context.Crashes.ToList();
            int pageSize = 450;
            var pageData = new CrashViewModel
            {
                Crashes = _context.Crashes
                            .OrderBy(crash => crash.CRASH_ID)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize),
                PageInfo = new PageInformation
                {
                    NumOfCrashes = _context.Crashes.Count(),
                    CrashesPerPage = pageSize,
                    CurrrentPage = pageNum
                }
            };

            return View(pageData);
        }

        [HttpGet]
        public IActionResult CreateEditCrash()
        {
            return View();
        }

        [HttpPost] // Create new crash
        public IActionResult CreateEditCrash(CrashModel crash)
        {
            if (ModelState.IsValid)
            {
                crash.CRASH_ID = _context.Crashes.Count() + 1;
                _context.Add(crash);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(crash);
        }

        [HttpGet]
        public IActionResult Edit(int crashId)
        {
            ViewBag.Added = false;

            var crash = _context.Crashes.Single(crash => crash.CRASH_ID == crashId);

            return View("CreateEditCrash", crash);
        }

        [HttpPost] // Edit existing crash
        public IActionResult Edit(CrashModel crash)
        {
            if (ModelState.IsValid)
            {
                _context.Update(crash);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(crash);
        }

        [HttpGet]
        public IActionResult Delete(int crashId)
        {
            var crash = _context.Crashes.Single(x => x.CRASH_ID == crashId);

            return View(crash);
        }

        [HttpPost]
        public IActionResult Delete(CrashModel crash)
        {
            _context.Crashes.Remove(crash);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
