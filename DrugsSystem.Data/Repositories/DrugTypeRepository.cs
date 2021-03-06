﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugsSystem.Data.Repositories
{
    public class DrugTypeRepository : BaseRepository<DrugType>, IDrugTypeRepository
    {
        public DrugTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
