using DelClub.Models.Data;
using DelClub.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFSushiBoxRepository : ISushiBoxRepository
    {
        private ApplicationDbContext context;
        public EFSushiBoxRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SushiBox> SushiBoxes => context.SushiBoxes;

        public IQueryable<SBOrder> SBOrders => context.SBOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.SushiBox);

        public void SaveSBOrder(SBOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.SushiBox));
            if (order.Id == 0)
            {
                context.SBOrders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
