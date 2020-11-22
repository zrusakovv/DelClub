using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    public class CartSushiBox
    {
        private List<SBCartLine> lineCollection = new List<SBCartLine>();

        //Добавление товара в корзину
        public virtual void AddItem(SushiBox sushiBox, int quantity)
        {
            SBCartLine line = lineCollection
                .Where(p => p.SushiBox.Id == sushiBox.Id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new SBCartLine
                {
                    SushiBox = sushiBox,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //Удаление товара из корзины
        public virtual void RemoveLine(SushiBox sushiBox) => lineCollection.RemoveAll(l => l.SushiBox.Id == sushiBox.Id);

        //Вычисление общей стоимости
        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.SushiBox.Price * e.Quantity);

        //Очистка
        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<SBCartLine> Lines => lineCollection;
    }



    public class SBCartLine
    {
        [Key]
        public int CartLineId { get; set; }
        public SushiBox SushiBox { get; set; }
        public int Quantity { get; set; }
    }
}
