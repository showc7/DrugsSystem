using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using DrugsSystem.Models;

namespace DrugsSystem.Data
{
    class DbInitializer : DropCreateDatabaseAlways<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            base.Seed(context);

            GetCountries().ForEach(x => context.Countries.Add(x));
            GetDepots().ForEach(x => context.Depots.Add(x));
            GetDrugTypes().ForEach(x => context.DrugTypes.Add(x));
            GetDrugUnits().ForEach(x => context.DrugUnits.Add(x));
            context.Commit();

            Depot dpt = context.Depots.First(x => x.DepotName.Equals("Depot-0"));
            if(dpt.DrugUnits == null)
            {
                dpt.DrugUnits = new List<DrugUnit>();
            }
            DrugUnit du = context.DrugUnits.First(y => y.PickNumber == 1);
            dpt.DrugUnits.Add(du);
            du = context.DrugUnits.First(y => y.PickNumber == 8);
            dpt.DrugUnits.Add(du);

            context.Commit();
        }

        private static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { CountryName = "Romania" },
                new Country { CountryName = "United States of America" }
            };
        }

        private static List<Depot> GetDepots()
        {
            return new List<Depot>
            {
                new Depot { DepotName = "Depot-0" },
                new Depot { DepotName = "Depot-1" }
            };
        }

        private static List<DrugType> GetDrugTypes()
        {
            return new List<DrugType>
            {
                new DrugType { DrugTypeName = "Type-0" },
                new DrugType { DrugTypeName = "Type-1" }
            };
        }

        private static List<DrugUnit> GetDrugUnits()
        {
            int drugUnitsCount = 100;
            var drugUnits = new List<DrugUnit>(drugUnitsCount);
            for (int i = 0; i < drugUnitsCount; i++)
            {
                drugUnits.Add(new DrugUnit { DrugUnitID = "a_" + i.ToString(), PickNumber = i });
            }
            return drugUnits;
        }
    }
}
