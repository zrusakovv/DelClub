using DelClub.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Data
{
    public class EFRestaurantRepository : IRestaurantRepository
    {
        private ApplicationDbContext context;
        public EFRestaurantRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Restaurant> Restaurants => context.Restaurants;
        
    }
}
