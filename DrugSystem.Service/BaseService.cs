using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Repositories;
using DrugsSystem.Data.Infrastructure;

namespace DrugSystem.Service
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;

        public BaseService(IDbFactory dbFactory)
        {
            _unitOfWork = new UnitOfWork(dbFactory);
        }
    }
}
