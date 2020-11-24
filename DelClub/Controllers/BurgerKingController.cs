using DelClub.Infrastructure;
using DelClub.Models;
using DelClub.Models.Interface;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        //Метод обработки нажатия на кнопку, добавления товара 
        [Authorize(Roles = "user")]
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

        //Метод обработки нажатия на кнопк, удаления товара
        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            BurgerKing burgerKing = repository.BurgerKings.FirstOrDefault(p => p.Id == Id);

            if (burgerKing != null)
            {
                cart.RemoveLine(burgerKing);
            }
            return RedirectToAction("BurgerKingList", new { returnUrl });
        }

        //Метод выводящий все сделанные заказы
        [Authorize(Roles = "moderator")]
        public ViewResult ListOrder() => View(repository.BKOrders.Where(o => !o.Shipped));

        //Метод сигннализирующий о принятии заказа в обработку
        [HttpPost]
        public IActionResult MarkShipped(int id)
        {
            BKOrder bKOrder = repository.BKOrders.FirstOrDefault(o => o.Id == id);
            if(bKOrder != null)
            {
                bKOrder.Shipped = true;
                repository.SaveBKOrder(bKOrder);
            }
            return RedirectToAction(nameof(ListOrder));
        }

        //Метод Checkout возвращает представление для указания адреса доставки
        [Authorize(Roles = "user")]
        public ViewResult Checkout() => View(new BKOrder());

        [HttpPost]
        public IActionResult Checkout(BKOrder order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините ваша корзина пуста");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveBKOrder(order);
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
        public ViewResult Index() => View(repository.BurgerKings);
        
        //Изменение товара
        public ViewResult Edit(int Id) =>
            View(repository.BurgerKings.FirstOrDefault(p => p.Id == Id));

        [HttpPost]
        public IActionResult Edit(BurgerKing burgerKing)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(burgerKing);
                TempData["message"] = $"{burgerKing.Name} был сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(burgerKing);
            }
        }

        //Метод создания новых товаров 
        public ViewResult Create() => View("Edit", new BurgerKing());

        //Метод удаления товаров из списка
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            BurgerKing deletedProduct = repository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }

    }
}
