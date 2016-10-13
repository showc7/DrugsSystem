using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Models;

namespace DrugSystem.Service
{
    public interface IDrugUnitService
    {
        IEnumerable<DrugUnit> getAll();
    }
}
