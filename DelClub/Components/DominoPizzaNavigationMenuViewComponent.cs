using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components
{
    public class DominoPizzaNavigationMenuViewComponent : ViewComponent
    {
        private IDominoPizzaRepository repository;
        public DominoPizzaNavigationMenuViewComponent(IDominoPizzaRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.DominoPizzas
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
