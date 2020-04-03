using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PaulWeissInSite.API.Entities
{
    public class vCommunityNewsContext : DbContext
    {
        public vCommunityNewsContext(DbContextOptions<vCommunityNewsContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<vCommunityNews> vCommunityNews { get; set; }
    }
}

