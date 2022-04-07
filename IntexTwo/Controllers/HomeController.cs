using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IntexTwo.Models;
using IntexTwo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace IntexTwo.Controllers
{
    public class HomeController : Controller
    {
        private CrashesDbContext _context { get; set; }

        public HomeController(CrashesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crashes(string cityName, int pageNum = 1)
        {
            ViewBag.CityName = cityName ?? "Home";

            var crashes = _context.Crashes.ToList();
            int pageSize = 50;
            var pageData = new CrashViewModel
            {
                Crashes = _context.Crashes
                            .Where(crash => crash.CITY == cityName || cityName == null) // filter
                            .OrderBy(crash => crash.CRASH_ID)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize),

                PageInfo = new PageInformation
                {
                    NumOfCrashes = _context.Crashes.Count(),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(pageData);
        }

        public IActionResult CrashDetails(int crashId)
        {
            var crash = _context.Crashes.Single(x => x.CRASH_ID == crashId);

            return View(crash);
        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}

