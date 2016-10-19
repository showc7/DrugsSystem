using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrugsSystem.WebUI.Models.OrderUnits
{
    public class OrderResult
    {
        public List<string> Names { get; set; }
        public List<string> Values { get; set; }

        public OrderResult()
        {
            Names = new List<string>();
            Values = new List<string>();
        }
    }
}