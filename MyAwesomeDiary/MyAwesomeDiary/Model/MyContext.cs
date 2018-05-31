﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MyAwesomeDiary.Model
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MADStringConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<SpecialDay> SpecialDays { get; set; }
        public DbSet<NationalDay> NationalDays { get; set; }
    }
}
