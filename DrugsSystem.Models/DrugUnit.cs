using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models
{
    public class DrugUnit: BaseEntity
    {
        [Key]
        public string DrugUnitID { get; set; }
        public int PickNumber { get; set; }
        public virtual DrugType DrugType { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", PickNumber);
        }
    }
}
