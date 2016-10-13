using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrugsSystem.Models.Database;
using System.Data.Entity;

namespace DrugsSystem.DAL
{
    public class DrugsContext : DbContext
    {
        public DrugsContext() : base("DrugsSystem")
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<DrugType> Drugtypes { get; set; }
        public DbSet<DrugUnit> DrugUnits { get; set; }
    }
}