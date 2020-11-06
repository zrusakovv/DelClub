using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components
{
    public class MakdonaldsNavigationMenuViewComponent : ViewComponent
    {
        private IFoodRepository repository;

        public MakdonaldsNavigationMenuViewComponent(IFoodRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Foods
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
