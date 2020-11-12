using DelClub.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Controllers
{
    public class MakdonaldsSummaryViewComponent : ViewComponent
    {
        private Makdonalds makdonalds;

        public MakdonaldsSummaryViewComponent(Makdonalds makdonalds)
        {
            this.makdonalds = makdonalds;
        }

        public IViewComponentResult Invoke()
        {
            return View(makdonalds);
        }
    }
}
