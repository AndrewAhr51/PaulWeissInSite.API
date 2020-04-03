using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaulWeissInSite.API.Models;
using PaulWeissInSite.API.Services;
using AutoMapper;

namespace PaulWeissInSite.API.Controllers
{
    [Route("api/")]
    public class vRecentHiresController : Controller
    {
        private ILogger<vRecentHiresController> _logger;
        private IMailService _mailService;
        private IvRecentHiresRepository _recentHiresRepository;

        public vRecentHiresController(IvRecentHiresRepository vRecentHiresRepository, ILogger<vRecentHiresController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _recentHiresRepository = vRecentHiresRepository;
        }

        [HttpGet("RecentHires")]
        public IActionResult GetRecentHires()
        {
            try
            {
                var recentHiresEntities = _recentHiresRepository.GetRecentHires();
                
                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<vRecentHiresDto>>(recentHiresEntities);
                
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Recent Hires.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }
    }
}
