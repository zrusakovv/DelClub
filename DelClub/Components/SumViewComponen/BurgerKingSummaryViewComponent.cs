using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components.SumViewComponen
{
    public class BurgerKingSummaryViewComponent : ViewComponent
    {
        private CartBurgerKing cart;

        public BurgerKingSummaryViewComponent(CartBurgerKing cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
