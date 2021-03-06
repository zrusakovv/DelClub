﻿using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Controllers
{
    //Навигация по категориям продуктов
    public class SushiBoxNavigationMenuViewComponent : ViewComponent
    {
        private ISushiBoxRepository repository;
        public SushiBoxNavigationMenuViewComponent(ISushiBoxRepository repository)
        {
            this.repository = repository;
        }

        //Выборка и упорядочивание набора категорияй
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.SushiBoxes
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
