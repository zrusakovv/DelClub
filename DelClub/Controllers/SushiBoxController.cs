﻿using DelClub.Infrastructure;
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

        //Метод обработки нажатия на кнопку, добавления товара 
        [Authorize(Roles = "user")]
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

        //Метод обработки нажатия на кнопк, удаления товара
        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            SushiBox sushiBox = repository.SushiBoxes.FirstOrDefault(p => p.Id == Id);

            if (sushiBox != null)
            {
                cart.RemoveLine(sushiBox);
            }
            return RedirectToAction("SushiBoxList", new { returnUrl });
        }

        //Метод выводящий все сделанные заказы
        [Authorize(Roles = "moderator")]
        public ViewResult ListOrder() => View(repository.SBOrders.Where(o => !o.Shipped));

        //Метод сигннализирующий о принятии заказа в обработку
        [HttpPost]
        public IActionResult MarkShipped(int id)
        {
            SBOrder sBOrder = repository.SBOrders.FirstOrDefault(o => o.Id == id);
            if (sBOrder != null)
            {
                sBOrder.Shipped = true;
                repository.SaveSBOrder(sBOrder);
            }
            return RedirectToAction(nameof(ListOrder));
        }

        //Метод Checkout возвращает представление для указания адреса доставки
        [Authorize(Roles = "user")]
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

        //Метод выводит все товары для администрирования
        [Authorize(Roles = "moderator")]
        public ViewResult Index() => View(repository.SushiBoxes);

        //Изменение товара
        public ViewResult Edit(int Id) =>
            View(repository.SushiBoxes.FirstOrDefault(p => p.Id == Id));

        [HttpPost]
        public IActionResult Edit(SushiBox sushiBox)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(sushiBox);
                TempData["message"] = $"{sushiBox.Name} был сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(sushiBox);
            }
        }

        //Метод создания новых товаров 
        public ViewResult Create() => View("Edit", new SushiBox());

        //Метод удаления товаров из списка
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            SushiBox deletedProduct = repository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }
    }
}
