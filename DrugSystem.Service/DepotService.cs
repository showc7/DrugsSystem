using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Repositories;
using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

using AutoMapper;

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

        IEnumerable<Models.DrugUnitDTO> IDepotService.GetAssociatedDrugUnits(Depot entity)
        {
            // remove configuration to Global.asax ?????
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnit, Models.DrugUnitDTO>());
            return _depotRepository.GetAssociatedDrugUnits(entity.DepotID).Select(x => Mapper.Map<Models.DrugUnitDTO>(x));
        }
    }
}
