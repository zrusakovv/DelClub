using DelClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    public class MakdonaldsListViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public string CurrentCategory { get; set; }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
