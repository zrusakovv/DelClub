using DelClub.Models.Interface;
using DelClub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantRepository repository;
        public HomeController(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(string category)
        {

            return View(new RestaurantListViewModel
            {
                Restaurants = repository.Restaurants
                .Where(r => category == null || r.Category == category),
                CurrentCategory = category
            });
        }
    }
}
