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
    public class CountryService : BaseService, ICountryService
    {
        private ICountryRepository _countryRepository;

        public CountryService(IDbFactory dbFactory) : base(dbFactory)
        {
            _countryRepository = _unitOfWork.CountryRepository;
        }

        IEnumerable<Country> ICountryService.GetAll()
        {
            return _countryRepository.GetAll();
        }
    }
}
