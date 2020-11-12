using DelClub.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Data
{
    public class EFMakdonaldsRepository : IMakdonaldsRepository
    {
        private ApplicationDbContext context;
        public EFMakdonaldsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Makdonalds> Makdonalds => context.Makdonalds;

        public IQueryable<MDOrder> MDOrders => context.MDOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Makdonalds);

        public void SaveMDOrder(MDOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.Makdonalds));
            if (order.Id == 0)
            {
                context.MDOrders.Add(order);
            }
            context.SaveChanges();
        }

        public void SaveProduct(Makdonalds makdonalds)
        {
            if (makdonalds.Id == 0)
            {
                context.Makdonalds.Add(makdonalds);
            }
            else
            {
                Makdonalds dbEntry = context.Makdonalds.FirstOrDefault(p => p.Id == makdonalds.Id);
                if (dbEntry != null)
                {
                    dbEntry.Img = makdonalds.Img;
                    dbEntry.Name = makdonalds.Name;
                    dbEntry.Description = makdonalds.Description;
                    dbEntry.Category = makdonalds.Category;
                    dbEntry.Price = makdonalds.Price;
                }
            }
            context.SaveChanges();
        }

        public Makdonalds DeleteProduct(int Id)
        {
            Makdonalds dbEntry = context.Makdonalds.FirstOrDefault(p => p.Id == Id);
            if(dbEntry != null)
            {
                context.Makdonalds.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
