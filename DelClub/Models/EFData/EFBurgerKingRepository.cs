using DelClub.Models.Data;
using DelClub.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFBurgerKingRepository : IBurgerKingRepository
    {
        private ApplicationDbContext context;
        public EFBurgerKingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<BurgerKing> BurgerKings => context.BurgerKings;
    }
}
