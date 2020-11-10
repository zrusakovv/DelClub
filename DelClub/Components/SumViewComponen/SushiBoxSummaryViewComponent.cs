using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Components.SumViewComponen
{
    public class SushiBoxSummaryViewComponent : ViewComponent
    {
        private CartSushiBox cart;
        public SushiBoxSummaryViewComponent(CartSushiBox cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
