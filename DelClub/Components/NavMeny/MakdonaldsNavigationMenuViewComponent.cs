using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components
{
    //Навигация по категориям продуктов
    public class MakdonaldsNavigationMenuViewComponent : ViewComponent
    {
        private IMakdonaldsRepository repository;

        public MakdonaldsNavigationMenuViewComponent(IMakdonaldsRepository repo)
        {
            repository = repo;
        }

        //Выборка и упорядочивание набора категорияй
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
