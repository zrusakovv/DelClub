using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    public class CartBurgerKing
    {
        private List<BKCartLine> lineCollection = new List<BKCartLine>();

        public virtual void AddItem(BurgerKing burgerKing, int quantity)
        {
            BKCartLine line = lineCollection
                .Where(p => p.BurgerKing.Id == burgerKing.Id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new BKCartLine
                {
                    BurgerKing = burgerKing,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(BurgerKing burgerKing) => lineCollection.RemoveAll(l => l.BurgerKing.Id == burgerKing.Id);

        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.BurgerKing.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<BKCartLine> Lines => lineCollection;
    }



    public class BKCartLine
    {
        [Key]
        public int CartLineId { get; set; }
        public BurgerKing BurgerKing { get; set; }
        public int Quantity { get; set; }
    }
}
