using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models.Database
{
    public class DrugUnit
    {
        [Key]
        public string DrugUnitID { get; set; }
        public int PickNumber { get; set; }
        public DrugType DrugTypes { get; set; }

        public override string ToString()
        {
            return string.Format("DrugUnitID: {0} PickNumber: {1}", this.DrugUnitID, this.PickNumber);
        }
    }
}