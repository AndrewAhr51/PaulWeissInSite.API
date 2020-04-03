using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public class vRecentHiresRepository: IvRecentHiresRepository
    {
        private vRecentHiresContext _context;

        public vRecentHiresRepository(vRecentHiresContext context)
        {
            _context = context;
        }
        public IEnumerable<vRecentHires> GetRecentHires()
        {
            return _context.vRecentHires.OrderByDescending(c => c.HireDate)
                .OrderBy(c=> c.LastName).ThenBy (c=> c.FirstName)
                .ToList();
        }
    }
}
