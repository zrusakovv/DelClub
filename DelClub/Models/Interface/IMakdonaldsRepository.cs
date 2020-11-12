using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Interface
{
    public interface IMakdonaldsRepository
    {
        IEnumerable<Makdonalds> Makdonalds { get; }
        IQueryable<MDOrder> MDOrders { get; }
        void SaveMDOrder(MDOrder order);
        void SaveProduct(Makdonalds makdonalds);
        Makdonalds DeleteProduct(int Id);
    }
}
