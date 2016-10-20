using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugsSystem.Data.Infrastructure
{
    public class DbFactory : DisposableObject, IDbFactory
    {
        StoreEntities _dbContext;

        public StoreEntities Init()
        {
            return _dbContext ?? (_dbContext = new StoreEntities());
        }

        protected override void DisposeCore()
        {
            if(_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
