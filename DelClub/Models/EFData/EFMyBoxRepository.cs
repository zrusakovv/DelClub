using DelClub.Models.Data;
using DelClub.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFMyBoxRepository : IMyBoxRepository
    {
        private ApplicationDbContext context;
        public EFMyBoxRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<MyBox> MyBoxes => context.MyBoxes;
    }
}
