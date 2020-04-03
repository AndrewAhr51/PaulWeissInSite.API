using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public class FirmEventRepository : IFirmEventRepository
    {
        private FirmEventsContext _context;

        public FirmEventRepository(FirmEventsContext context)
        {
            _context = context;
        }

        public IEnumerable<FirmEvents> GetFirmEvents()
        {
            return _context.FirmEvents.OrderBy(c => c.SortOrder).ToList();
        }
    }
}
