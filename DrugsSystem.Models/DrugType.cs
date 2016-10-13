using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models
{
    public class DrugType: BaseEntity
    {
        [Key]
        public int DrugTypeID { get; set; }
        public string DrugTypeName { get; set; }
        public virtual List<DrugUnit> DrugUnits { get; set; }
    }
}
