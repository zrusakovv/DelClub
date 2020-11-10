using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Interface
{
    public interface IMyBoxRepository
    {
        IEnumerable<MyBox> MyBoxes { get; }
        IQueryable<MBOrder> MBOrders { get; }
        void SaveMBOrder(MBOrder order);
    }
}
