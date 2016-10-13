using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DrugsSystem.Models.Database
{
    public class DrugType
    {
        [Key]
        public int DrugTypeID { get; set; }
        public string DrugTypeName { get; set; }
        public virtual List<DrugUnit> DrugUnits { get; set; }
    }
}