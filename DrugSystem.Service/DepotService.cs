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
    public class DepotService : BaseService, IDepotService
    {
        private IDepotRepository _depotRepository;

        public DepotService(IDbFactory dbFactory) : base(dbFactory)
        {
            _depotRepository = _unitOfWork.DepotRepository;
        }

        IEnumerable<Depot> IDepotService.GetAll()
        {
            return _depotRepository.GetAll();
        }

        IEnumerable<Country> IDepotService.GetAssociatedCountries(Depot entity)
        {
            return _depotRepository.GetAssociatedCountires(entity.DepotID);
        }

        IEnumerable<DrugUnit> IDepotService.GetAssociatedDrugUnits(Depot entity)
        {
            return _depotRepository.GetAssociatedDrugUnits(entity.DepotID);
        }
    }
}
