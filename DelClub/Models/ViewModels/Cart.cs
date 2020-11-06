using System.Collections.Generic;
using System.Linq;

namespace DelClub.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Food food, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Food.Id == food.Id).FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Food = food,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Food food) => lineCollection.RemoveAll(l => l.Food.Id == food.Id);

        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.Food.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }



    public class CartLine
    {
        public int CartLineId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
    }
}
