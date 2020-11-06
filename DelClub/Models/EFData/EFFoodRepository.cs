using DelClub.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Data
{
    public class EFFoodRepository : IFoodRepository
    {
        private ApplicationDbContext context;
        public EFFoodRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Food> Foods => context.Foods;
    }
}
