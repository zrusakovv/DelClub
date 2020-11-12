using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DelClub.Models
{
    public class CartMakdonalds
    {
        private List<MDCartLine> lineCollection = new List<MDCartLine>();

        public virtual void AddItem(Makdonalds makdonalds, int quantity)
        {
            MDCartLine line = lineCollection
                .Where(p => p.Makdonalds.Id == makdonalds.Id).FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new MDCartLine
                {
                    Makdonalds = makdonalds,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Makdonalds makdonalds) => lineCollection.RemoveAll(l => l.Makdonalds.Id == makdonalds.Id);

        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.Makdonalds.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<MDCartLine> Lines => lineCollection;
    }



    public class MDCartLine
    {
        [Key]
        public int CartLineId { get; set; }
        public Makdonalds Makdonalds { get; set; }
        public int Quantity { get; set; }
    }
}
