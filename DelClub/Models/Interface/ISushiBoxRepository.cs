using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Interface
{
    public interface ISushiBoxRepository
    {
        IEnumerable<SushiBox> SushiBoxes { get; }
        IQueryable<SBOrder> SBOrders { get; }
        void SaveSBOrder(SBOrder order);
    }
}
