using DelClub.Models.Data;
using DelClub.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFMyBoxRepository : IMyBoxRepository
    {
        private ApplicationDbContext context;
        public EFMyBoxRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<MyBox> MyBoxes => context.MyBoxes;

        //Метод извлечения заказов
        public IQueryable<MBOrder> MBOrders => context.MBOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.MyBox);

        //Метод сохранения заказов
        public void SaveMBOrder(MBOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.MyBox));
            if (order.Id == 0)
            {
                context.MBOrders.Add(order);
            }
            context.SaveChanges();
        }

        //Сохранение продукта
        public void SaveProduct(MyBox myBox)
        {
            if (myBox.Id == 0)
            {
                context.MyBoxes.Add(myBox);
            }
            else
            {
                MyBox dbEntry = context.MyBoxes.FirstOrDefault(p => p.Id == myBox.Id);
                if (dbEntry != null)
                {
                    dbEntry.Img = myBox.Img;
                    dbEntry.Name = myBox.Name;
                    dbEntry.Description = myBox.Description;
                    dbEntry.Category = myBox.Category;
                    dbEntry.Price = myBox.Price;
                }
            }
            context.SaveChanges();
        }

        //Удаление продукта
        public MyBox DeleteProduct(int Id)
        {
            MyBox dbEntry = context.MyBoxes.FirstOrDefault(p => p.Id == Id);
            if (dbEntry != null)
            {
                context.MyBoxes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
