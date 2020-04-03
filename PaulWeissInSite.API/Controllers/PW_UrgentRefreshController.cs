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
    public class PW_UrgentRefreshController : Controller
    {
        private ILogger<PW_UrgentRefreshController> _logger;
        private IMailService _mailService;
        private IPW_UrgentRefreshRepository _pw_UrgentRefreshRepository;

        public PW_UrgentRefreshController(IPW_UrgentRefreshRepository pw_UrgentRefreshRepository, ILogger<PW_UrgentRefreshController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _pw_UrgentRefreshRepository = pw_UrgentRefreshRepository;
        }

        [HttpGet("UrgentRefresh")]
        public IActionResult GetUrgentRefresh()
        {
            try
            {
                var urgentRefreshEntities = _pw_UrgentRefreshRepository.GetUrgentRefresh();

                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<PW_UrgentRefreshDto>>(urgentRefreshEntities);
               
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Urgent Refresh Items.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }


    }
}
