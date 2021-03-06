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

        //Метод обработки нажатия на кнопку, добавления товара 
        [Authorize(Roles = "user")]
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

        //Метод обработки нажатия на кнопк, удаления товара
        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            DominoPizza dominoPizza = repository.DominoPizzas.FirstOrDefault(p => p.Id == Id);

            if (dominoPizza != null)
            {
                cart.RemoveLine(dominoPizza);
            }
            return RedirectToAction("DominoPizzaList", new { returnUrl });
        }

        //Метод выводящий все сделанные заказы
        [Authorize(Roles = "moderator")]
        public ViewResult ListOrder() => View(repository.DPOrders.Where(o => !o.Shipped));

        //Метод сигннализирующий о принятии заказа в обработку
        [HttpPost]
        public IActionResult MarkShipped(int id)
        {
            DPOrder dPOrder = repository.DPOrders.FirstOrDefault(o => o.Id == id);
            if (dPOrder != null)
            {
                dPOrder.Shipped = true;
                repository.SaveDPOrder(dPOrder);
            }
            return RedirectToAction(nameof(ListOrder));
        }

        //Метод Checkout возвращает представление для указания адреса доставки
        [Authorize(Roles = "user")]
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

        //Метод выводит все товары для администрирования
        [Authorize(Roles = "moderator")]
        public ViewResult Index() => View(repository.DominoPizzas);

        //Изменение товара
        public ViewResult Edit(int Id) =>
            View(repository.DominoPizzas.FirstOrDefault(p => p.Id == Id));

        [HttpPost]
        public IActionResult Edit(DominoPizza dominoPizza)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(dominoPizza);
                TempData["message"] = $"{dominoPizza.Name} был сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(dominoPizza);
            }
        }

        //Метод создания новых товаров 
        public ViewResult Create() => View("Edit", new DominoPizza());

        //Метод удаления товаров из списка
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            DominoPizza deletedProduct = repository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }
    }
}
