using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components
{
    public class BurgerKingNavigationMenuViewComponent : ViewComponent
    {
        private IBurgerKingRepository repository;
        public BurgerKingNavigationMenuViewComponent(IBurgerKingRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.BurgerKings
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
