﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrugsSystem.Data.Infrastructure;
using DrugsSystem.Models;

namespace DrugsSystem.Data.Repositories
{
    public class DepotRepository : BaseRepository<Depot>, IDepotRepository
    {
        public DepotRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
