using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public interface IvRecentHiresRepository
    {
        IEnumerable<vRecentHires> GetRecentHires();
    }
}
