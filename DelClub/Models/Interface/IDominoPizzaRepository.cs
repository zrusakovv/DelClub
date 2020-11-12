using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Interface
{
    public interface IDominoPizzaRepository
    {
        IEnumerable<DominoPizza> DominoPizzas { get; }
        IQueryable<DPOrder> DPOrders { get; }
        void SaveDPOrder(DPOrder order);
        void SaveProduct(DominoPizza dominoPizza);
        DominoPizza DeleteProduct(int Id);
    }
}
