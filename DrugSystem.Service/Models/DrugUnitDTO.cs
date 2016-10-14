using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.Service.Models
{
    public class DrugUnitDTO
    {
        public string DrugUnitID { get; set; }
        public int PickNumber { get; set; }
        public DrugTypeDTO DrugTypes { get; set; }
    }
}
