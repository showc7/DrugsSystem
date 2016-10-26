using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrugsSystem.WebUI.Models
{
    public class DrugUnitDepotJsonModel
    {
        public class JsonRow
        {
            public class Cell
            {
                public string id { get; set; }
                public int selectedIndex { get; set; }
                public string[] values { get; set; }
                public int[] ids { get; set; }
                public int pickNumber { get; set; }
                public string DrugUnitID { get; set; }

                public Cell(string id, int selectedIndex, int pickNumber, string drugUnitID)
                {
                    this.id = id;
                    this.selectedIndex = selectedIndex;
                    this.pickNumber = pickNumber;
                    this.DrugUnitID = drugUnitID;
                }
            }

            public string id { get; set; }
            public Cell cell { get; set; }

            public JsonRow(string id)
            {
                this.id = id;
            }
        }

        public int page { get; set; }
        public int total { get; set; }
        public int records { get; set; }
        public JsonRow[] rows { get; set; }

        public DrugUnitDepotJsonModel(int page, int total, int records)
        {
            this.page = page;
            this.total = total;
            this.records = records;
        }
    }
}