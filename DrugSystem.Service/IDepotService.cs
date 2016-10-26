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
        IEnumerable<Models.DrugUnitDTO> GetAssociatedDrugUnits(Depot entity);
        IEnumerable<Country> GetAssociatedCountries(Depot entity);
        List<DrugType> GetAssociatedDrugTypes(int id);
        Models.OrderResultDTO MakeOrder(Models.OrderDTO order);
        Depot GetById(int? id);
        void UpdateEntity(Depot depot);
    }
}
