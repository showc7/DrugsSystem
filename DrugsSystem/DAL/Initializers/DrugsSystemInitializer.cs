using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrugsSystem.Models.Database;
using System.Data.Entity;
using NLog;

namespace DrugsSystem.DAL.Initializers
{
    public class DrugsSystemInitializer : DropCreateDatabaseIfModelChanges<DrugsContext>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void Seed(DrugsContext context)
        {
            logger.Info("Seed");
            base.Seed(context);

            var countries = new List<Country>
            {
                new Country { CountryName = "Romania" },
                new Country { CountryName = "United States of America" }
            };
            countries.ForEach(x => context.Countries.Add(x));
            context.SaveChanges();

            var depots = new List<Depot>
            {
                new Depot { DepotName = "Depot-0" },
                new Depot { DepotName = "Depot-1" }
            };
            depots.ForEach(x => context.Depots.Add(x));
            context.SaveChanges();

            var dragTypes = new List<DrugType>
            {
                new DrugType { DrugTypeName = "Type-0" },
                new DrugType { DrugTypeName = "Type-1" }
            };
            dragTypes.ForEach(x => context.Drugtypes.Add(x));
            context.SaveChanges();

            var drugUnits = new List<DrugUnit>(100);
            for(int i = 0; i < 100; i++)
            {
                drugUnits.Add(new DrugUnit { DrugUnitID = "a_" + i.ToString(), PickNumber = i });
            }
            drugUnits.ForEach(x => context.DrugUnits.Add(x));
            context.SaveChanges();

            logger.Info("Seed Finished");
        }
    }
}