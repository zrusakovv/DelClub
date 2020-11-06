using DelClub.Models;
using DelClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    public class KfcListViewModel
    {
        public IEnumerable<Kfc> Kfcs { get; set; }
        public string CurrentCategory { get; set; }
        public CartKfc Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
