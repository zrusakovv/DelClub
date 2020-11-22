using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DelClub.Components
{
    //Навигация по категориям продуктов
    public class BurgerKingNavigationMenuViewComponent : ViewComponent
    {
        private IBurgerKingRepository repository;
        public BurgerKingNavigationMenuViewComponent(IBurgerKingRepository repository)
        {
            this.repository = repository;
        }

        //Выборка и упорядочивание набора категорияй
        public IViewComponentResult Invoke()
        {
            return View(repository.BurgerKings
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
