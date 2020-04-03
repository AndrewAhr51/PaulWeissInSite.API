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
    public class FirmEventsController : Controller
    {

        private ILogger<FirmEventsController> _logger;
        private IMailService _mailService;
        private IFirmEventRepository _firmEventRepository;


        public FirmEventsController(IFirmEventRepository firmEventRepository, ILogger<FirmEventsController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _firmEventRepository = firmEventRepository;
        }

        [HttpGet("FirmEvents")]
        public IActionResult GetFirmEvents()
        {
            try
            {
                var firmEventEntities = _firmEventRepository.GetFirmEvents();

                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<FirmEventDto>>(firmEventEntities);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Firm Events.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }
    }
}
