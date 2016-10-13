using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models.Database
{
    public class Depot
    {
        [Key]
        public int DepotID { get; set; }
        public string DepotName { get; set; }
        public virtual List<DrugUnit> Drugunits { get; set; }
        public virtual List<Country> Countries { get; set; }
    }
}