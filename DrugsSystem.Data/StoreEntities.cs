using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using DrugsSystem.Models;

namespace DrugsSystem.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities")
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; } 
        public DbSet<DrugUnit> DrugUnits { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
