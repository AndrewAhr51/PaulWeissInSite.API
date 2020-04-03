using Microsoft.EntityFrameworkCore;

namespace PaulWeissInSite.API.Entities
{
    public class FirmEventsContext:DbContext
    {
        public FirmEventsContext(DbContextOptions<FirmEventsContext> options)
            :base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<FirmEvents> FirmEvents { get; set; }
    }
}
