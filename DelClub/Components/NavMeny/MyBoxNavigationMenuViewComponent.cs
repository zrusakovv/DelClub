using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components
{
    //Навигация по категориям продуктов
    public class MyBoxNavigationMenuViewComponent : ViewComponent
    {
        private IMyBoxRepository repository;
        public MyBoxNavigationMenuViewComponent(IMyBoxRepository repository)
        {
            this.repository = repository;
        }

        //Выборка и упорядочивание набора категорияй
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
