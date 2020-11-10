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
    public class MyBoxController : Controller
    {
        private IMyBoxRepository repository;
        private CartMyBox cart;
        public MyBoxController(IMyBoxRepository repository, CartMyBox cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public ViewResult MyBoxList(string category, string returnUrl)
            => View(new MyBoxListViewModel
            {
                MyBoxes = repository.MyBoxes
                .Where(p => category == null || p.Category == category),
                CurrentCategory = category,

                Cart = cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            MyBox myBox = repository.MyBoxes
                .FirstOrDefault(p => p.Id == Id);
            if (myBox != null)
            {
                cart.AddItem(myBox, 1);
            }
            return RedirectToAction("MyBoxList", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            MyBox myBox = repository.MyBoxes.FirstOrDefault(p => p.Id == Id);

            if (myBox != null)
            {
                cart.RemoveLine(myBox);
            }
            return RedirectToAction("MyBoxList", new { returnUrl });
        }

        public ViewResult Checkout() => View(new MBOrder());

        [HttpPost]
        public IActionResult Checkout(MBOrder order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините ваша корзина пуста");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveMBOrder(order);
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
