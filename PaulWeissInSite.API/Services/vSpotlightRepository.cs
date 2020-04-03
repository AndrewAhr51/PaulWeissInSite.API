using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public class vSpotlightRepository: IvSpotlightRepository
    {
        private vSpotlightContext _context;

        public vSpotlightRepository(vSpotlightContext context)
        {
            _context = context;
        }
        public IEnumerable<vSpotlight> GetSpotlight()
        {
            return _context.vSpotlight.ToList();
        }
    }
}
