using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Models;
using DrugSystem.Service.Models;

namespace DrugSystem.Service
{
    public interface IDrugUnitService
    {
        IEnumerable<DrugUnit> getAll();
        DrugUnitAssociatedViewDataDTO GetAssociatedViewData(string id);
        DrugUnit GetByPickNumber(int pickNumber);
        DrugUnit getByID(string id);
    }
}
