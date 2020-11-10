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
    public class SushiBoxController : Controller
    {
        private ISushiBoxRepository repository;
        private CartSushiBox cart;
        public SushiBoxController(ISushiBoxRepository repository, CartSushiBox cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public ViewResult SushiBoxList(string category, string returnUrl)
            => View(new SushiBoxListViewModel
            {
                SushiBoxes = repository.SushiBoxes
                .Where(p => category == null || p.Category == category),
                CurrentCategory = category,

                Cart = cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            SushiBox sushiBox = repository.SushiBoxes
                .FirstOrDefault(p => p.Id == Id);
            if (sushiBox != null)
            {
                cart.AddItem(sushiBox, 1);
            }
            return RedirectToAction("SushiBoxList", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            SushiBox sushiBox = repository.SushiBoxes.FirstOrDefault(p => p.Id == Id);

            if (sushiBox != null)
            {
                cart.RemoveLine(sushiBox);
            }
            return RedirectToAction("SushiBoxList", new { returnUrl });
        }

        public ViewResult Checkout() => View(new SBOrder());

        [HttpPost]
        public IActionResult Checkout(SBOrder order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините ваша корзина пуста");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveSBOrder(order);
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
