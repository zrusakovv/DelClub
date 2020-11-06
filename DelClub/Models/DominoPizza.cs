using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models
{
    public class DominoPizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public string Time { get; set; }
        public string DeliveryPrice { get; set; }
        public string DeliveryPriceFrom { get; set; }
    }
}
