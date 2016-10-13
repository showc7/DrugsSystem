using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugsSystem.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private StoreEntities _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public StoreEntities DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = _dbFactory.Init());
            }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
