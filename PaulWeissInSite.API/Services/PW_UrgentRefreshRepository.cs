using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public class PW_UrgentRefreshRepository : IPW_UrgentRefreshRepository
    {
        private PW_UrgentRefreshContext _context;
        public PW_UrgentRefreshRepository(PW_UrgentRefreshContext context)
        {
            _context = context;
        }
        public IEnumerable<PW_UrgentRefresh> GetUrgentRefresh()
        {
            return _context.PW_UrgentRefresh.OrderByDescending(c => c.__Modified).ToList();
        }
    }
}
