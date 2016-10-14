using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Repositories;
using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugSystem.Service
{
    public class DrugUnitService : BaseService, IDrugUnitService
    {
        private IDrugUnitRepository _drugUnitRepository;
        public DrugUnitService(IDbFactory dbFactory) : base(dbFactory)
        {
            _drugUnitRepository = _unitOfWork.DrugUnitRepository;
        }

        IEnumerable<DrugUnit> IDrugUnitService.getAll()
        {
            return _drugUnitRepository.GetAll();
        }
    }
}
