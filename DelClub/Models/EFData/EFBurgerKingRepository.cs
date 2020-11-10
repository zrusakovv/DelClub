using DelClub.Models.Data;
using DelClub.Models.Interface;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<BKOrder> BKOrders => context.BKOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.BurgerKing);

        public void SaveBKOrder(BKOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.BurgerKing));
            if (order.Id == 0)
            {
                context.BKOrders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
