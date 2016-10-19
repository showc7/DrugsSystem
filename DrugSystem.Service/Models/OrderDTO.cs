using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.Service.Models
{
    public class OrderDTO
    {
        public List<int> IDs { get; set; }
        public List<int> Values { get; set; }
        public int DepotID { get; set; }

        public OrderDTO()
        {
            IDs = new List<int>();
            Values = new List<int>();
        }
    }
}
