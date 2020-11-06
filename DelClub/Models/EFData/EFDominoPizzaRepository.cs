using DelClub.Models.Data;
using DelClub.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFDominoPizzaRepository : IDominoPizzaRepository
    {
        private ApplicationDbContext context;
        public EFDominoPizzaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DominoPizza> DominoPizzas => context.DominoPizzas;
    }
}
