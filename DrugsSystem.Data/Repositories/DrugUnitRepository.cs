using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugsSystem.Data.Repositories
{
    class DrugUnitRepository : BaseRepository<DrugUnit>, IDrugUnitRepository
    {
        public DrugUnitRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
