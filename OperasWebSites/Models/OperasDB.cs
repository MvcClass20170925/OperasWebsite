﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OperasWebSites.Models
{
    public class OperasDB : DbContext
    {
        public DbSet<Opera> Operas { get; set; }
    }
}