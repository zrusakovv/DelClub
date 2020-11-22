using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    //Корзина покупок
    public class CartDominoPizza
    {

        private List<DPCartLine> lineCollection = new List<DPCartLine>();

        //Добавление товара в корзину
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

        //Удаление товара из корзины
        public virtual void RemoveLine(DominoPizza dominoPizza) => lineCollection.RemoveAll(l => l.DominoPizza.Id == dominoPizza.Id);

        //Вычисление общей стоимости
        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.DominoPizza.Price * e.Quantity);

        //Очистка
        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<DPCartLine> Lines => lineCollection;
    }



    public class DPCartLine
    {
        [Key]
        public int CartLineId { get; set; }
        public DominoPizza DominoPizza { get; set; }
        public int Quantity { get; set; }
    }
}
