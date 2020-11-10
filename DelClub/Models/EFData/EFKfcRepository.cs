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

        public IQueryable<KfcOrder> KfcOrders => context.KfcOrders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Kfc);

        public void SaveKfcOrder(KfcOrder order)
        {
            context.AttachRange(order.Lines.Select(l => l.Kfc));
            if (order.Id == 0)
            {
                context.KfcOrders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
