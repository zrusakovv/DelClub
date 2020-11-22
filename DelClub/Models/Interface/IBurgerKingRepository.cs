using System.Collections.Generic;
using System.Linq;

namespace DelClub.Models.Interface
{
    public interface IBurgerKingRepository
    {
        IEnumerable<BurgerKing> BurgerKings { get; }
        IQueryable<BKOrder> BKOrders { get; }
        void SaveBKOrder(BKOrder order);
        void SaveProduct(BurgerKing burgerKing);
        BurgerKing DeleteProduct(int Id);
    }
}
