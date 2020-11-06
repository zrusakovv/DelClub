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
    public class KfcController : Controller
    {
        private IKfcRepository repository;
        CartKfc cart;
        public KfcController(IKfcRepository repository, CartKfc cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public ViewResult KfcList(string category, string returnUrl)
            => View(new KfcListViewModel
            {
                Kfcs = repository.Kfcs
                .Where(p => category == null || p.Category == category),
                CurrentCategory = category,

                Cart = cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            Kfc kfc = repository.Kfcs
                .FirstOrDefault(p => p.Id == Id);
            if (kfc != null)
            {
                cart.AddItem(kfc, 1);
            }
            return RedirectToAction("KfcList", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            Kfc kfc = repository.Kfcs.FirstOrDefault(p => p.Id == Id);

            if (kfc != null)
            {
                cart.RemoveLine(kfc);
            }
            return RedirectToAction("KfcList", new { returnUrl });
        }
    }
}
