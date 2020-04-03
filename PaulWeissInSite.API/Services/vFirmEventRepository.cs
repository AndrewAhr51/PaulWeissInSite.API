using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public class vFirmEventRepository : IvFirmEventRepository
    {
        private vFirmEventsContext _context;

        public vFirmEventRepository(vFirmEventsContext context)
        {
            _context = context;
        }

        public IEnumerable<vFirmEvents> GetAllFirmEvents()
        {
            return _context.vFirmEvents.OrderBy(c => c.SortOrder).ToList();
        }
    }
}
