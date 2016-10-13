using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models
{
    public class Country: BaseEntity
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public virtual List<Depot> Depots { get; set; }
    }
}
