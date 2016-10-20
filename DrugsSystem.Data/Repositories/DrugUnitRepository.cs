using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugsSystem.Data.Repositories
{
    public class DrugUnitRepository : BaseRepository<DrugUnit>, IDrugUnitRepository
    {
        public DrugUnitRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public DrugUnit GetById(string id)
        {
            return DbContext.DrugUnits.Where(x => x.DrugUnitID == id).FirstOrDefault();
        }

        public DrugUnit GetByPickNumber(int pickNumber)
        {
            return DbContext.DrugUnits.Where(x => x.PickNumber == pickNumber).FirstOrDefault();
        }
    }
}
