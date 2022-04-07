using System;
using System.Linq;

namespace IntexTwo.Models.ViewModels
{
    public class CrashViewModel
    {
        public IQueryable<CrashModel> Crashes { get; set; }
        public PageInformation PageInfo { get; set; }
    }
}
