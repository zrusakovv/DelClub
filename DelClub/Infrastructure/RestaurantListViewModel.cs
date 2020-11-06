using DelClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.ViewModels
{
    public class RestaurantListViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentCategory { get; set; }
    }
}
