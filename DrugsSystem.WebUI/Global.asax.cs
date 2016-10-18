using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DrugsSystem.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitalizeAutomapper();
        }

        protected void InitalizeAutomapper()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Models.ViewModelDrugUnit, DrugSystem.Service.Models.DrugUnitDepotUpdateServiceModel>()
                    .ForMember(dest => dest.DepotID, opt => opt.MapFrom(c => c.SelectedDepotID));
                cfg.CreateMap<SelectListItem, SelectListItem>();
                cfg.CreateMap<DrugsSystem.Models.Depot, SelectListItem>()
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(c => c.ToString()))
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(c => c.DepotID.ToString()));
                cfg.CreateMap<DrugSystem.Service.Models.DrugUnitDepot, Models.ViewModelDrugUnit>()
                    .ForMember(dest => dest.SelectedDepotID, opt => opt.MapFrom(c => c.Depot.DepotID ))
                    .ForMember(dest => dest.DrugUnitID, opt => opt.MapFrom(c => c.DrugUnit.DrugUnitID))
                    .ForMember(dest => dest.DrugUnitPickNumber, opt => opt.MapFrom(c => c.DrugUnit.PickNumber));
                cfg.CreateMap<DrugsSystem.Models.DrugUnit, SelectListItem>()
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(c => c.ToString()))
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(c => c.DrugUnitID));
            });
        }
    }
}
