using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Repositories;

namespace DrugsSystem.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get; }
        IDepotRepository DepotRepository { get; }
        IDrugTypeRepository DrugTypeRepository { get; }
        IDrugUnitRepository DrugUnitrepository { get; }
        void Commit();
    }
}
