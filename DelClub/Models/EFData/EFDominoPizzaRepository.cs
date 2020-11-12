using DelClub.Models.Data;
using DelClub.Models.Interface;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<DPOrder> DPOrders => context.DPOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.DominoPizza);

        public void SaveDPOrder(DPOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.DominoPizza));
            if (order.Id == 0)
            {
                context.DPOrders.Add(order);
            }
            context.SaveChanges();
        }

        public void SaveProduct(DominoPizza dominoPizza)
        {
            if (dominoPizza.Id == 0)
            {
                context.DominoPizzas.Add(dominoPizza);
            }
            else
            {
                DominoPizza dbEntry = context.DominoPizzas.FirstOrDefault(p => p.Id == dominoPizza.Id);
                if (dbEntry != null)
                {
                    dbEntry.Img = dominoPizza.Img;
                    dbEntry.Name = dominoPizza.Name;
                    dbEntry.Description = dominoPizza.Description;
                    dbEntry.Category = dominoPizza.Category;
                    dbEntry.Price = dominoPizza.Price;
                }
            }
            context.SaveChanges();
        }

        public DominoPizza DeleteProduct(int Id)
        {
            DominoPizza dbEntry = context.DominoPizzas.FirstOrDefault(p => p.Id == Id);
            if (dbEntry != null)
            {
                context.DominoPizzas.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
