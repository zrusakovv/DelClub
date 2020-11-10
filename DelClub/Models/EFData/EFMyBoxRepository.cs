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

        public IQueryable<MBOrder> MBOrders => context.MBOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.MyBox);

        public void SaveMBOrder(MBOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.MyBox));
            if (order.Id == 0)
            {
                context.MBOrders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
