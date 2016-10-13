using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Models;

namespace DrugSystem.Service
{
    public interface IDepotService
    {
        IEnumerable<Depot> GetAll();
        IEnumerable<DrugUnit> GetAssociatedDrugUnits(Depot entity);
        IEnumerable<Country> GetAssociatedCountries(Depot entity);
    }
}
