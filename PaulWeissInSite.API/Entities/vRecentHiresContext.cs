using Microsoft.EntityFrameworkCore;

namespace PaulWeissInSite.API.Entities
{
    public class vRecentHiresContext:DbContext
    {
        public vRecentHiresContext(DbContextOptions<vRecentHiresContext> options)
                  : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<vRecentHires> vRecentHires { get; set; }
    }
}
