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
        void UpdatedrugUnitWithDepot(List<DrugUnitDepotUpdateServiceModel> updateModels);
    }
}
