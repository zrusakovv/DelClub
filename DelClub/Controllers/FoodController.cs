using DelClub.Infrastructure;
using DelClub.Models;
using DelClub.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DelClub.Controllers
{
    public class FoodController : Controller
    {
        private IFoodRepository repository;
        private Cart cart;
        public FoodController(IFoodRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult ListFood(string category, string returnUrl) =>
            View(new MakdonaldsListViewModel
            {
                Foods = repository.Foods
                .Where(p=>category == null || p.Category == category),
                CurrentCategory = category,

                Cart = cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            Food food = repository.Foods
                .FirstOrDefault(p => p.Id == Id);
            if (food != null)
            {
                cart.AddItem(food, 1);
            }
            return RedirectToAction("ListFood", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            Food food = repository.Foods.FirstOrDefault(p => p.Id == Id);

            if (food != null)
            {
                cart.RemoveLine(food);
            }
            return RedirectToAction("ListFood", new { returnUrl });
        }

    }
}
