using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugSystem.Service.Models;

namespace DrugSystem.Service
{
    public interface IDrugUnitDepotService
    {
        List<DrugUnitDepot> DrugUnitWithDepot();
        void UpdateDrugUnitWithDepot(List<DrugUnitDepotUpdateServiceModel> updateModels);
        List<DrugUnitDepot> DrugUnitWithDepot(int offset, int count);
        int GetDrugUnitsCount();
        void AssociateDrugUnitWithDepot(string drugUnitID, int depotID);
    }
}
