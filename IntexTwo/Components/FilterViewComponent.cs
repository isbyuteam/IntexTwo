using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntexTwo.Models;

namespace IntexTwo.Components
{
    public class FilterViewComponent : ViewComponent
    {
        private CrashesDbContext _context { get; set; }

        public FilterViewComponent(CrashesDbContext temp)
        {
            _context = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Cities = RouteData?.Values["crashCity"];

            var cities = _context.Crashes
                .Select(crash => crash.CITY)
                .Distinct()
                .OrderBy(city => city);

            return View(cities);
        }
    }
}
