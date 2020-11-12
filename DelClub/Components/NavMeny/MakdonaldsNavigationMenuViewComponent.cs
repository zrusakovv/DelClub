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
        private IMakdonaldsRepository repository;

        public MakdonaldsNavigationMenuViewComponent(IMakdonaldsRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Makdonalds
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
