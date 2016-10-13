using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models.Drugs
{
    public class EditViewModel
    {
        public List<Database.DrugType> DrugTypes { get; set; }
        [Display(Name = "ID")]
        public string DrugUnitID { get; set; }
        [Display(Name = "PickNumber")]
        public int PickNumber { get; set; }
        public EditViewModel(Database.DrugUnit unit)
        {
            this.DrugTypes = unit.DrugTypes;
            this.DrugUnitID = unit.DrugUnitID;
            this.PickNumber = unit.PickNumber;
        }
    }
}