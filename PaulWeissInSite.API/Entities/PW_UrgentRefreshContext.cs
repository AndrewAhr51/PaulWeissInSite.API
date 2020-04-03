using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PaulWeissInSite.API.Entities
{
    public class PW_UrgentRefreshContext:DbContext
    {
        public PW_UrgentRefreshContext(DbContextOptions<PW_UrgentRefreshContext> options)
                   : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<PW_UrgentRefresh> PW_UrgentRefresh { get; set; }
    }
}
