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
            var depot = _depotRepository.GetByDrugUnitID(id);
            result.DepotName = depot?.DepotName;
            
            if (depot != null && depot.Countries != null && depot.Countries.Count > 0)
            {
                result.CountryName = depot.Countries[0].CountryName;
            }

            var drugUnit = _drugUnitRepository.GetById(id);
            if(drugUnit != null && drugUnit.DrugType != null)
            result.DrugTypeName = drugUnit.DrugType.DrugTypeName;
            result.DrugUnitID = id;
            result.PickNumber = _drugUnitRepository.GetById(id).PickNumber;
            return result;
        }

        IEnumerable<DrugUnit> IDrugUnitService.getAll()
        {
            return _drugUnitRepository.GetAll();
        }

        public DrugUnit GetByPickNumber(int pickNumber)
        {
            return _drugUnitRepository.GetByPickNumber(pickNumber);
        }
    }
}
