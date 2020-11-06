using DelClub.Models.Data;
using DelClub.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.EFData
{
    public class EFKfcRepository : IKfcRepository
    {
        private ApplicationDbContext context;
        public EFKfcRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Kfc> Kfcs => context.Kfcs;
    }
}
