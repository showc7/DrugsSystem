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

        public List<DrugType> GetAssociatedDrugTypes(int id)
        {
            List<DrugType> result = new List<DrugType>();

            Depot depot = _depotRepository.GetById(id);
            depot.DrugUnits.ForEach(drugUnit =>
            {
                if(result.Count > 0 && !result.Any(r => r.DrugTypeID == drugUnit.DrugType.DrugTypeID))
                {
                    result.Add(drugUnit.DrugType);
                }
                if(result.Count == 0)
                {
                    result.Add(drugUnit.DrugType);
                }
            });

            return result;
        }

        public Models.OrderResultDTO MakeOrder(Models.OrderDTO order)
        {
            Models.OrderResultDTO or = new Models.OrderResultDTO();

            Depot depot = _depotRepository.GetById(order.DepotID);
            List<DrugUnit> drugUnits = depot.DrugUnits;

            for(int idx = 0; idx < order.IDs.Count; idx++ )
            {
                int typeID = order.IDs[idx];
                int quantity = order.Values[idx];

                foreach(DrugUnit du in drugUnits)
                {
                    if(du.DrugType.DrugTypeID == typeID && du.Quantity > 0)
                    {
                        int quantityResult = Math.Min(quantity, du.Quantity);
                        if(quantityResult > 0)
                        {
                            quantity -= quantityResult;
                            or.drugUnitID.Add(du.DrugUnitID);
                            or.Values.Add(quantityResult);
                            or.Names.Add(du.DrugUnitID);
                        }
                    }
                }
            }

            return or;
        }

        public Depot GetById(int? id)
        {
            return _depotRepository.GetById(id);
        }
    }
}
