using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.Service.Models
{
    public class OrderResultDTO
    {
        public List<int> IDs { get; set; }
        public List<int> Values { get; set; }
        public List<string> drugUnitID { get; set; }

        public OrderResultDTO()
        {
            IDs = new List<int>();
            Values = new List<int>();
            drugUnitID = new List<string>();
        }
    }
}
