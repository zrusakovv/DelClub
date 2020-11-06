using DelClub.Models;
using DelClub.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Infrastructure
{
    public class MyBoxListViewModel
    {
        public IEnumerable<MyBox> MyBoxes { get; set; }
        public string CurrentCategory { get; set; }
        public CartMyBox Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
