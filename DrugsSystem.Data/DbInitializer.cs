using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using DrugsSystem.Models;

namespace DrugsSystem.Data
{
    //class DbInitializer : CreateDatabaseIfNotExists<StoreEntities>
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

            Country country = context.Countries.First(x => x.CountryName.Equals("Romania"));
            Depot dpt = context.Depots.First(x => x.DepotName.Equals("Depot-0"));
            country.Depots = new List<Depot>();
            country.Depots.Add(dpt);
            if(dpt.DrugUnits == null)
            {
                dpt.DrugUnits = new List<DrugUnit>();
            }
            DrugUnit du = context.DrugUnits.First(y => y.PickNumber == 1);
            DrugUnit du1 = context.DrugUnits.First(y => y.PickNumber == 2);
            DrugType dt = context.DrugTypes.First(t => t.DrugTypeName == "Type-0");
            du.DrugType = dt;
            du.Quantity = 4;
            du1.DrugType = dt;
            if (dt.DrugUnits == null)
            {
                dt.DrugUnits = new List<DrugUnit>();
            }
            dt.DrugUnits.Add(du);
            dt.DrugUnits.Add(du1);
            dpt.DrugUnits.Add(du);
            dpt.DrugUnits.Add(du1);
            du = context.DrugUnits.First(y => y.PickNumber == 8);
            du.Quantity = 3;
            du.DrugType = dt;
            if (dt.DrugUnits == null)
            {
                dt.DrugUnits = new List<DrugUnit>();
            }
            dt.DrugUnits.Add(du);
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
