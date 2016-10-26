using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models
{
    public class Depot: BaseEntity
    {
        [Key]
        public int DepotID { get; set; }
        public string DepotName { get; set; }
        public virtual List<DrugUnit> DrugUnits { get; set; }
        public virtual List<Country> Countries { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", DepotName);
        }

        public override bool Equals(object obj)
        {
            if((obj as Depot) == null)
            {
                return false;
            }

            return (obj as Depot).DepotID == DepotID;
        }
    }
}
