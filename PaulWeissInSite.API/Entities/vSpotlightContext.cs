using Microsoft.EntityFrameworkCore;

namespace PaulWeissInSite.API.Entities
{
    public class vSpotlightContext:DbContext
    {
        public vSpotlightContext(DbContextOptions<vSpotlightContext> options)
              : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<vSpotlight> vSpotlight { get; set; }
    }
}
