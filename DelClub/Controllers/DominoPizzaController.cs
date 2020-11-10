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
    public class DominoPizzaController : Controller
    {
        private IDominoPizzaRepository repository;
        private CartDominoPizza cart;
        public DominoPizzaController(IDominoPizzaRepository repository, CartDominoPizza cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public ViewResult DominoPizzaList(string category, string returnUrl)
            => View(new DominoPizzaListViewModel
            {
                DominoPizzas = repository.DominoPizzas
                .Where(p => category == null || p.Category == category),
                CurrentCategory = category,

                Cart = cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            DominoPizza dominoPizza = repository.DominoPizzas
                .FirstOrDefault(p => p.Id == Id);
            if (dominoPizza != null)
            {
                cart.AddItem(dominoPizza, 1);
            }
            return RedirectToAction("DominoPizzaList", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            DominoPizza dominoPizza = repository.DominoPizzas.FirstOrDefault(p => p.Id == Id);

            if (dominoPizza != null)
            {
                cart.RemoveLine(dominoPizza);
            }
            return RedirectToAction("DominoPizzaList", new { returnUrl });
        }

        public ViewResult Checkout() => View(new DPOrder());

        [HttpPost]
        public IActionResult Checkout(DPOrder order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините ваша корзина пуста");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveDPOrder(order);
                cart.Clear();
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            return View();
        }
    }
}
