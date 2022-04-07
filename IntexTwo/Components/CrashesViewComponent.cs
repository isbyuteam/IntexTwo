using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntexTwo.Models;

namespace intex2.Components
{
    public class CrashesViewComponent : ViewComponent
    {
        private CrashesDbContext _context { get; set; }

        public CrashesViewComponent(CrashesDbContext temp)
        {
            _context = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["crashCity"];

            var cities = _context.Crashes
                .Select(x => x.CITY)
                .Distinct()
                .OrderBy(x => x);

            return View(cities);
        }
    }
}