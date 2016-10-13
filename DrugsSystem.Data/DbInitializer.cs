﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using DrugsSystem.Models;

namespace DrugsSystem.Data
{
    class DbInitializer : DropCreateDatabaseIfModelChanges<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            base.Seed(context);

            GetCountries().ForEach(x => context.Countries.Add(x));
            GetDepots().ForEach(x => context.Depots.Add(x));
            GetDrugTypes().ForEach(x => context.DrugTypes.Add(x));
            GetDrugUnits().ForEach(x => context.DrugUnits.Add(x));

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
            var drugUnits = new List<DrugUnit>(100);
            for (int i = 0; i < 100; i++)
            {
                drugUnits.Add(new DrugUnit { DrugUnitID = "a_" + i.ToString(), PickNumber = i });
            }
            return drugUnits;

        }
    }
}
