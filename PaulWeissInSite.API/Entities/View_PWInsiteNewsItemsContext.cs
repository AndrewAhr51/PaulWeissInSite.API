using Microsoft.EntityFrameworkCore;

namespace PaulWeissInSite.API.Entities
{
    public class View_PWInsiteNewsItemsContext : DbContext
    {
        public View_PWInsiteNewsItemsContext(DbContextOptions<View_PWInsiteNewsItemsContext> options)
            :base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<View_PWInsiteNewsItems> View_PWInsiteNewsItems { get; set; }
    }
}
