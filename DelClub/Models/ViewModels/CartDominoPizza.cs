using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    public class CartDominoPizza
    {

        private List<DPCartLine> lineCollection = new List<DPCartLine>();

        public virtual void AddItem(DominoPizza dominoPizza, int quantity)
        {
            DPCartLine line = lineCollection
                .Where(p => p.DominoPizza.Id == dominoPizza.Id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new DPCartLine
                {
                    DominoPizza = dominoPizza,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(DominoPizza dominoPizza) => lineCollection.RemoveAll(l => l.DominoPizza.Id == dominoPizza.Id);

        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.DominoPizza.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<DPCartLine> Lines => lineCollection;
    }



    public class DPCartLine
    {
        public int CartLineId { get; set; }
        public DominoPizza DominoPizza { get; set; }
        public int Quantity { get; set; }
    }
}
