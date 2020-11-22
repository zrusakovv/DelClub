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

        //Метод обработки нажатия на кнопку, добавления товара 
        [Authorize(Roles = "user")]
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

        //Метод обработки нажатия на кнопк, удаления товара
        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            MyBox myBox = repository.MyBoxes.FirstOrDefault(p => p.Id == Id);

            if (myBox != null)
            {
                cart.RemoveLine(myBox);
            }
            return RedirectToAction("MyBoxList", new { returnUrl });
        }

        //Метод выводящий все сделанные заказы
        [Authorize(Roles = "moderator")]
        public ViewResult ListOrder() => View(repository.MBOrders.Where(o => !o.Shipped));

        //Метод сигннализирующий о принятии заказа в обработку
        [HttpPost]
        public IActionResult MarkShipped(int id)
        {
            MBOrder mBOrder = repository.MBOrders.FirstOrDefault(o => o.Id == id);
            if (mBOrder != null)
            {
                mBOrder.Shipped = true;
                repository.SaveMBOrder(mBOrder);
            }
            return RedirectToAction(nameof(ListOrder));
        }

        //Метод Checkout возвращает представление для указания адреса доставки
        [Authorize(Roles = "user")]
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

        //Метод выводит все товары для администрирования
        [Authorize(Roles = "admin")]
        public ViewResult Index() => View(repository.MyBoxes);

        public ViewResult Edit(int Id) =>
            View(repository.MyBoxes.FirstOrDefault(p => p.Id == Id));

        //Изменение товара
        [HttpPost]
        public IActionResult Edit(MyBox myBox)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(myBox);
                TempData["message"] = $"{myBox.Name} был сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(myBox);
            }
        }

        //Метод создания новых товаров
        public ViewResult Create() => View("Edit", new MyBox());

        //Метод удаления товаров из списка
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            MyBox deletedProduct = repository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }
    }
}
