using DelClub.Infrastructure;
using DelClub.Models;
using DelClub.Models.Interface;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        //Метод обработки нажатия на кнопку, добавления товара
        [Authorize(Roles = "user")]
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

        //Метод обработки нажатия на кнопк, удаления товара
        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            Kfc kfc = repository.Kfcs.FirstOrDefault(p => p.Id == Id);

            if (kfc != null)
            {
                cart.RemoveLine(kfc);
            }
            return RedirectToAction("KfcList", new { returnUrl });
        }

        //Метод выводящий все сделанные заказы
        [Authorize(Roles = "moderator")]
        public ViewResult ListOrder() => View(repository.KfcOrders.Where(o => !o.Shipped));

        //Метод сигннализирующий о принятии заказа в обработку
        [HttpPost]
        public IActionResult MarkShipped(int id)
        {
            KfcOrder kfcOrder = repository.KfcOrders.FirstOrDefault(o => o.Id == id);
            if (kfcOrder != null)
            {
                kfcOrder.Shipped = true;
                repository.SaveKfcOrder(kfcOrder);
            }
            return RedirectToAction(nameof(ListOrder));
        }

        //Метод Checkout возвращает представление для указания адреса доставки
        [Authorize(Roles = "user")]
        public ViewResult Checkout() => View(new KfcOrder());

        [HttpPost]
        public IActionResult Checkout(KfcOrder order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините ваша корзина пуста");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveKfcOrder(order);
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

        //Метод выводит все товары для администрирования
        [Authorize(Roles = "moderator")]
        public ViewResult Index() => View(repository.Kfcs);

        //Изменение товара
        public ViewResult Edit(int Id) =>
            View(repository.Kfcs.FirstOrDefault(p => p.Id == Id));

        [HttpPost]
        public IActionResult Edit(Kfc kfc)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(kfc);
                TempData["message"] = $"{kfc.Name} был сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(kfc);
            }
        }

        //Метод создания новых товаров 
        public ViewResult Create() => View("Edit", new Kfc());

        //Метод удаления товаров из списка
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Kfc deletedProduct = repository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }
    }
}
