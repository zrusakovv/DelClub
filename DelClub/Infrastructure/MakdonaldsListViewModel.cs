using DelClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    public class MakdonaldsListViewModel
    {
        public IEnumerable<Makdonalds> Makdonalds { get; set; }
        public string CurrentCategory { get; set; }

        public CartMakdonalds Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
