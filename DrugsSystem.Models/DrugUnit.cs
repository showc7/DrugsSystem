using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models
{
    public class DrugUnit
    {
        [Key]
        public string DrugUnitID { get; set; }
        public int PickNumber { get; set; }
        public DrugType DrugTypes { get; set; }
    }
}
