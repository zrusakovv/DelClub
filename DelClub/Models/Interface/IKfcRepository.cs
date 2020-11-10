using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Interface
{
    public interface IKfcRepository
    {
        IEnumerable<Kfc> Kfcs { get; }
        IQueryable<KfcOrder> KfcOrders { get; }
        void SaveKfcOrder(KfcOrder order);
    }
}
