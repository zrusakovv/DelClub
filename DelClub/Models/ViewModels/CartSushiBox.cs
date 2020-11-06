﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    public class CartSushiBox
    {
        private List<SBCartLine> lineCollection = new List<SBCartLine>();

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

        public virtual void RemoveLine(SushiBox sushiBox) => lineCollection.RemoveAll(l => l.SushiBox.Id == sushiBox.Id);

        public virtual int ComputeTotalValue() => lineCollection.Sum(e => e.SushiBox.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<SBCartLine> Lines => lineCollection;
    }



    public class SBCartLine
    {
        public int CartLineId { get; set; }
        public SushiBox SushiBox { get; set; }
        public int Quantity { get; set; }
    }
}