using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Repositories;

namespace DrugsSystem.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private StoreEntities _dbContext;

        private ICountryRepository _countryRepository;
        private IDepotRepository _depotRepository { get; }
        private IDrugTypeRepository _drugTypeRepository { get; }
        private IDrugUnitRepository _drugUnitRepository { get; }

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;

            _countryRepository = new CountryRepository(_dbFactory);
            _depotRepository = new DepotRepository(_dbFactory);
            _drugTypeRepository = new DrugTypeRepository(_dbFactory);
            _drugUnitRepository = new DrugUnitRepository(_dbFactory);
        }

        public StoreEntities DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = _dbFactory.Init());
            }
        }
        
        ICountryRepository IUnitOfWork.CountryRepository
        {
            get
            {
                return _countryRepository;
            }
        }
        
        IDepotRepository IUnitOfWork.DepotRepository
        {
            get
            {
                return _depotRepository;
            }
        }

        IDrugTypeRepository IUnitOfWork.DrugTypeRepository
        {
            get
            {
                return _drugTypeRepository;
            }
        }

        IDrugUnitRepository IUnitOfWork.DrugUnitRepository
        {
            get
            {
                return _drugUnitRepository;
            }
        }

        public void Commit()
        {
            // add exception catching
            DbContext.Commit();
        }

        void IUnitOfWork.Commit()
        {
            throw new NotImplementedException();
        }
    }
}
