using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Repositories;
using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;
using DrugSystem.Service.Models;

namespace DrugSystem.Service
{
    public class DrugUnitsDepotService : BaseService, IDrugUnitDepotService
    {
        IDrugUnitService _drugUnitService;
        IDepotService _depotService;

        public DrugUnitsDepotService(IDbFactory dbFactory) : base(dbFactory)
        {
            _drugUnitService = new DrugUnitService(dbFactory);
            _depotService = new DepotService(dbFactory);
        }

        // метод получающий drugUnit и его Depot
        public List<DrugUnitDepot> DrugUnitWithDepot()
        {
            List<DrugUnitDepot> result = new List<DrugUnitDepot>();

            foreach (DrugUnit du in _drugUnitService.getAll())
            {
                result.Add(new DrugUnitDepot(du, _depotService.GetAll().FirstOrDefault(x => x.DrugUnits != null && x.DrugUnits.Count != 0 && x.DrugUnits.Contains(du))));
            }

            return result;
        }

        public void UpdateDrugUnitWithDepot(List<DrugUnitDepotUpdateServiceModel> updateModels)
        {
            foreach(var v in updateModels)
            {
                //fields:
                //  v.DepotID;
                //  v.DrugUnitPickNumber;
                /* злостный костыль */
                if(v.DepotID == null)
                {
                    continue;
                }

                var drugUnit = _drugUnitService.GetByPickNumber(v.DrugUnitPickNumber);
                var depot = _depotService.GetById(v.DepotID);
                bool contains = depot.DrugUnits.Contains(drugUnit);
                if(!contains)
                {
                    depot.DrugUnits.Add(drugUnit);
                }
            }
        }

        public void AssociateDrugUnitWithDepot(string drugUnitID, int depotID)
        {
            DrugUnit drugUnit = _drugUnitService.getByID(drugUnitID);
            Depot depot = _depotService.GetById(depotID);
            bool contains = depot.DrugUnits.Contains(drugUnit);
            if (!contains)
            {
                depot.DrugUnits.Add(drugUnit);
                _depotService.UpdateEntity(depot);
            }
        }

        public List<DrugUnitDepot> DrugUnitWithDepot(int offset, int count)
        {
            return DrugUnitWithDepot().GetRange(offset, count);
        }

        public int GetDrugUnitsCount()
        {
            return DrugUnitWithDepot().Count;
        }
    }
}
