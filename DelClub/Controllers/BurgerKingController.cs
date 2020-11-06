using DelClub.Infrastructure;
using DelClub.Models;
using DelClub.Models.Interface;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Controllers
{
    public class BurgerKingController : Controller
    {
        private IBurgerKingRepository repository;
        private CartBurgerKing cart;

        public BurgerKingController(IBurgerKingRepository repository, CartBurgerKing cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public ViewResult BurgerKingList(string category, string returnUrl) =>
            View(new BurgerKingsListViewModel
            {
                BurgerKings = repository.BurgerKings
                .Where(p => category == null || p.Category == category),
                CurrentCategory = category,

                Cart = cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            BurgerKing burgerKing = repository.BurgerKings
                .FirstOrDefault(p => p.Id == Id);
            if (burgerKing != null)
            {
                cart.AddItem(burgerKing, 1);
            }
            return RedirectToAction("BurgerKingList", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            BurgerKing burgerKing = repository.BurgerKings.FirstOrDefault(p => p.Id == Id);

            if (burgerKing != null)
            {
                cart.RemoveLine(burgerKing);
            }
            return RedirectToAction("BurgerKingList", new { returnUrl });
        }
    }
}
