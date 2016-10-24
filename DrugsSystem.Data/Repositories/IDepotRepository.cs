using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugsSystem.Data.Repositories
{
    public interface IDepotRepository : IRepository<Depot>
    {
        IEnumerable<Country> GetAssociatedCountires(int DepotID);
        IEnumerable<DrugUnit> GetAssociatedDrugUnits(int DepotID);
        Depot GetById(int? id);
        Depot GetByDrugUnitID(string id);
    }
}
