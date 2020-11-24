using DelClub.Infrastructure;
using DelClub.Models;
using DelClub.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DelClub.Controllers
{
    public class MakdonaldsController : Controller
    {
        private IMakdonaldsRepository repository;
        private CartMakdonalds cart;
        public MakdonaldsController(IMakdonaldsRepository repo, CartMakdonalds cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult MakdonaldsList(string category, string returnUrl) =>
            View(new MakdonaldsListViewModel
            {
                Makdonalds = repository.Makdonalds
                .Where(p=>category == null || p.Category == category),
                CurrentCategory = category,

                Cart = cart,
                ReturnUrl = returnUrl
            });

        //Метод обработки нажатия на кнопку, добавления товара 
        [Authorize(Roles = "user")]
        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            Makdonalds makdonalds = repository.Makdonalds
                .FirstOrDefault(p => p.Id == Id);
            if (makdonalds != null)
            {
                cart.AddItem(makdonalds, 1);
            }
            return RedirectToAction("MakdonaldsList", new { returnUrl });
        }

        //Метод обработки нажатия на кнопк, удаления товара
        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            Makdonalds makdonalds = repository.Makdonalds.FirstOrDefault(p => p.Id == Id);

            if (makdonalds != null)
            {
                cart.RemoveLine(makdonalds);
            }
            return RedirectToAction("MakdonaldsList", new { returnUrl });
        }

        //Метод выводящий все сделанные заказы
        [Authorize(Roles = "moderator")]
        public ViewResult ListOrder() => View(repository.MDOrders.Where(o => !o.Shipped));

        //Метод сигннализирующий о принятии заказа в обработку
        [HttpPost]
        public IActionResult MarkShipped(int id)
        {
            MDOrder mDOrder = repository.MDOrders.FirstOrDefault(o => o.Id == id);
            if (mDOrder != null)
            {
                mDOrder.Shipped = true;
                repository.SaveMDOrder(mDOrder);
            }
            return RedirectToAction(nameof(ListOrder));
        }

        //Метод Checkout возвращает представление для указания адреса доставки
        [Authorize(Roles = "user")]
        public ViewResult Checkout() => View(new MDOrder());

        [HttpPost]
        public IActionResult Checkout(MDOrder order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините ваша корзина пуста");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveMDOrder(order);
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
        public ViewResult Index() => View(repository.Makdonalds);

        //Изменение товара
        public ViewResult Edit(int Id) =>
            View(repository.Makdonalds.FirstOrDefault(p => p.Id == Id));

        [HttpPost]
        public IActionResult Edit(Makdonalds makdonalds)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(makdonalds);
                TempData["message"] = $"{makdonalds.Name} был сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(makdonalds);
            }
        }

        //Метод создания новых товаров 
        public ViewResult Create() => View("Edit", new Makdonalds());

        //Метод удаления товаров из списка
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Makdonalds deletedProduct = repository.DeleteProduct(Id);
            if(deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }
    }
}
