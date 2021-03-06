﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    public class CartMyBox
    {
        private List<MBCartLine> lineCollection = new List<MBCartLine>();

        //Добавление товара в корзину
        public virtual void AddItem(MyBox myBox, int quantity)
        {
            MBCartLine line = lineCollection
                .Where(p => p.MyBox.Id == myBox.Id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new MBCartLine
                {
                    MyBox = myBox,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //Удаление товара из корзины
        public virtual void RemoveLine(MyBox myBox) => lineCollection.RemoveAll(l => l.MyBox.Id == myBox.Id);

        //Вычисление общей стоимости
        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.MyBox.Price * e.Quantity);

        //Очистка
        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<MBCartLine> Lines => lineCollection;
    }



    public class MBCartLine
    {
        [Key]
        public int CartLineId { get; set; }
        public MyBox MyBox { get; set; }
        public int Quantity { get; set; }
    }
}
