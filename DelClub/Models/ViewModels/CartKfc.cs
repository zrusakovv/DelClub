using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    public class CartKfc
    {
        private List<KFCCartLine> lineCollection = new List<KFCCartLine>();

        public virtual void AddItem(Kfc kfc, int quantity)
        {
            KFCCartLine line = lineCollection
                .Where(p => p.Kfc.Id == kfc.Id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new KFCCartLine
                {
                    Kfc = kfc,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Kfc kfc) => lineCollection.RemoveAll(l => l.Kfc.Id == kfc.Id);

        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.Kfc.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<KFCCartLine> Lines => lineCollection;
    }



    public class KFCCartLine
    {
        [Key]
        public int CartLineId { get; set; }
        public Kfc Kfc { get; set; }
        public int Quantity { get; set; }
    }
}
