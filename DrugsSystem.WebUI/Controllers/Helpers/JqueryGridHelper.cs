using DrugSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrugsSystem.WebUI.Controllers.Helpers
{
    public class JqueryGridHelper
    {
        public static Models.DrugUnitDepotJsonModel DrugUnitDepotToModel(List<DrugUnitDepot> drugUnitWithDepot, List<DrugsSystem.Models.Depot> depots, int page, int total, int records)
        {
            Models.DrugUnitDepotJsonModel result = new Models.DrugUnitDepotJsonModel(page, total, records)
            {
                rows = new Models.DrugUnitDepotJsonModel.JsonRow[drugUnitWithDepot.Count]
            };

            for (int i = 0; i < drugUnitWithDepot.Count; i++)
            {
                var dud = drugUnitWithDepot[i];
                int selectedIndex = depots.IndexOf(dud.Depot);
                result.rows[i] = new Models.DrugUnitDepotJsonModel.JsonRow(dud.DrugUnit.DrugUnitID);
                result.rows[i].cell = new Models.DrugUnitDepotJsonModel.JsonRow.Cell(
                        dud.DrugUnit.DrugUnitID,
                        selectedIndex,
                        dud.DrugUnit.PickNumber,
                        dud.DrugUnit.DrugUnitID
                    );
                result.rows[i].cell.values = depots.Select(d => d.DepotName).ToArray();
                result.rows[i].cell.ids = depots.Select(d => d.DepotID).ToArray();
            }

            return result;
        }
    }
}