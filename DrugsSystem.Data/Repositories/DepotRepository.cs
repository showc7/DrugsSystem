using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugsSystem.Data.Repositories
{
    public class DepotRepository : BaseRepository<Depot>, IDepotRepository
    {
        public DepotRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Country> GetAssociatedCountires(int DepotID)
        {
            return this.DbContext.Depots.Where(x => x.DepotID == DepotID).FirstOrDefault().Countries.AsEnumerable();
        }

        public IEnumerable<DrugUnit> GetAssociatedDrugUnits(int DepotID)
        {
            return this.DbContext.Depots.Where(x => x.DepotID == DepotID).FirstOrDefault().DrugUnits.AsEnumerable();
        }
    }
}
