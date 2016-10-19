using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrugsSystem.WebUI.Models.OrderUnits;
using DrugsSystem.Models;
using System.Web.Mvc;

namespace DrugsSystem.WebUI.Controllers.Helpers
{
    public static class DepotsToListViewModel
    {
        public static ListViewModel ConvertDepotsToListViewModel(IEnumerable<Depot> depots)
        {
            ListViewModel result = new ListViewModel();

            (depots as List<Depot>).ForEach(x =>
            {
                result.DepotName.Add(x.DepotName);
                result.DepotID.Add(x.DepotID);
                result.Depots.Add(new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.DepotID.ToString()
                });
            });

            return result;
        }

        public static DrugTypesViewModel ConvertToSelectList(List<DrugType> drugTypes, int depotID)
        {
            DrugTypesViewModel result = new DrugTypesViewModel();

            drugTypes.ForEach(drugType =>
            {
                result.Values.Add("0");
                result.Names.Add(drugType.DrugTypeName);
                result.IDs.Add(drugType.DrugTypeID);
                result.DepotID = depotID;
            });

            return result;
        }

        public static OrderResult CalculateOrder(DrugTypesViewModel data, DrugSystem.Service.IDepotService _depotService)
        {
            OrderResult or = new OrderResult();
            DrugSystem.Service.Models.OrderDTO order = new DrugSystem.Service.Models.OrderDTO();

            data.IDs.ForEach(x => order.IDs.Add(x));
            data.Values.ForEach(x => order.Values.Add(int.Parse(x)));
            order.DepotID = data.DepotID;

            DrugSystem.Service.Models.OrderResultDTO res = _depotService.MakeOrder(order);
            res.Values.ForEach(x => or.Values.Add(x.ToString()));
            data.Names.ForEach(x => or.Names.Add(x));

            return or;
        }
    }
}