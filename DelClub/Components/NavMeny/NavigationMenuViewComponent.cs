using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components
{
    //Навигация по категориям продуктов
    public class NavigationMenuViewComponent  : ViewComponent
    {
        private IRestaurantRepository repository;
        public NavigationMenuViewComponent(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        //Выборка и упорядочивание набора категорияй
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Restaurants
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
