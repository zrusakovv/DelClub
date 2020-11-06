using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.Interface
{
    public interface IBurgerKingRepository
    {
        IEnumerable<BurgerKing> BurgerKings { get; }
    }
}
