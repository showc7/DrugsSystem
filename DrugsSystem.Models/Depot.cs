using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models
{
    public class Depot
    {
        [Key]
        public int DepotID { get; set; }
        public string DepotName { get; set; }
        public virtual List<DrugUnit> DrugUnits { get; set; }
        public virtual List<Country> Countries { get; set; }
    }
}
