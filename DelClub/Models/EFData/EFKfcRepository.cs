using DelClub.Models.Data;
using DelClub.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFKfcRepository : IKfcRepository
    {
        private ApplicationDbContext context;
        public EFKfcRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Kfc> Kfcs => context.Kfcs;

        //Метод извлечения заказов
        public IQueryable<KfcOrder> KfcOrders => context.KfcOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Kfc);

        //Метод сохранения заказов
        public void SaveKfcOrder(KfcOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.Kfc));
            if (order.Id == 0)
            {
                context.KfcOrders.Add(order);
            }
            context.SaveChanges();
        }

        //Сохранение продукта
        public void SaveProduct(Kfc kfc)
        {
            if (kfc.Id == 0)
            {
                context.Kfcs.Add(kfc);
            }
            else
            {
                Kfc dbEntry = context.Kfcs.FirstOrDefault(p => p.Id == kfc.Id);
                if (dbEntry != null)
                {
                    dbEntry.Img = kfc.Img;
                    dbEntry.Name = kfc.Name;
                    dbEntry.Description = kfc.Description;
                    dbEntry.Category = kfc.Category;
                    dbEntry.Price = kfc.Price;
                }
            }
            context.SaveChanges();
        }

        //Удаление продукта
        public Kfc DeleteProduct(int Id)
        {
            Kfc dbEntry = context.Kfcs.FirstOrDefault(p => p.Id == Id);
            if (dbEntry != null)
            {
                context.Kfcs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
