using DelClub.Models.Data;
using DelClub.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFSushiBoxRepository : ISushiBoxRepository
    {
        private ApplicationDbContext context;
        public EFSushiBoxRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<SushiBox> SushiBoxes => context.SushiBoxes;
    }
}
