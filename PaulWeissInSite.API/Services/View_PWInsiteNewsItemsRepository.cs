using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public class View_PWInsiteNewsItemsRepository : IView_PWInsiteNewsItemsRepository
    {
        private View_PWInsiteNewsItemsContext _context;

        public View_PWInsiteNewsItemsRepository(View_PWInsiteNewsItemsContext context)
        {
            _context = context;
        }

        public IEnumerable<View_PWInsiteNewsItems> GetNewsItems()
        {
            return _context.View_PWInsiteNewsItems.OrderBy(c => c.ID).ThenBy(c => c.HomePageSection)
                .Where(c => c.RunDate1 == DateTime.Today ||
                            c.RunDate2 == DateTime.Today ||
                            c.RunDate3 == DateTime.Today)
                .ToList();

        }

        public IEnumerable<View_PWInsiteNewsItems> GetLeadNews()
        {
            return _context.View_PWInsiteNewsItems.OrderByDescending(c => c.ID).ThenBy(c => c.HomePageSection)
                .Where(c => c.HomePageSection == "Lead Content").Take(10)
                .ToList();

        }
    }
}
