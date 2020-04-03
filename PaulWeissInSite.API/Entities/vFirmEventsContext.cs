using Microsoft.EntityFrameworkCore;

namespace PaulWeissInSite.API.Entities
{
    public class vFirmEventsContext:DbContext
    {
        public vFirmEventsContext(DbContextOptions<vFirmEventsContext> options)
            :base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<vFirmEvents> vFirmEvents { get; set; }
    }
}
