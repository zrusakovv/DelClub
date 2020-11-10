using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components
{
    public class MyBoxNavigationMenuViewComponent : ViewComponent
    {
        private IMyBoxRepository repository;
        public MyBoxNavigationMenuViewComponent(IMyBoxRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.MyBoxes
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
