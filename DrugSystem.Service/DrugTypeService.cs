using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Repositories;
using DrugsSystem.Data.Infrastructure;

namespace DrugSystem.Service
{
    public class DrugTypeService : BaseService, IDrugTypeService
    {
        private IDrugTypeRepository _drugTypeRepository;

        public DrugTypeService(IDbFactory dbFactory) : base(dbFactory)
        {
            _drugTypeRepository = _unitOfWork.DrugTypeRepository;
        }
    }
}
