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
    public class DrugUnitService : BaseService, IDrugUnitService
    {
        private IDrugUnitRepository _drugUnitRepository;
        private IDepotRepository _depotRepository;
        public DrugUnitService(IDbFactory dbFactory) : base(dbFactory)
        {
            _drugUnitRepository = _unitOfWork.DrugUnitRepository;
            _depotRepository = _unitOfWork.DepotRepository;
        }

        public DrugUnitAssociatedViewDataDTO GetAssociatedViewData(string id)
        {
            // Depot Name
            // Country Name
            // Drug Type Name
            // Drug Unit Id
            // Pick Number
            var result = new DrugUnitAssociatedViewDataDTO();
            result.DepotName = _depotRepository.GetAll().FirstOrDefault(x => x.DrugUnits.Any(c => c.DrugUnitID == id)).DepotName;
            var countries = _depotRepository.GetAll().FirstOrDefault(x => x.DrugUnits.Any(c => c.DrugUnitID == id));
            if (countries.Countries != null && countries.Countries.Count > 0)
            {
                result.CountryName = countries.Countries[0].CountryName;
            }
            var drugTypes = _drugUnitRepository.GetAll().FirstOrDefault(x => x.DrugUnitID == id);
            if(drugTypes != null && drugTypes.DrugType != null)
            result.DrugTypeName = drugTypes.DrugType.DrugTypeName;
            result.DrugUnitID = id;
            result.PickNumber = _drugUnitRepository.GetAll().FirstOrDefault(x => x.DrugUnitID == id).PickNumber;
            return result;
        }

        IEnumerable<DrugUnit> IDrugUnitService.getAll()
        {
            return _drugUnitRepository.GetAll();
        }
    }
}
