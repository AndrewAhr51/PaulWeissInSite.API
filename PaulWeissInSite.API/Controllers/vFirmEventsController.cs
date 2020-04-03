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
    public class vFirmEventsController :Controller
    {
        private ILogger<vFirmEventsController> _logger;
        private IMailService _mailService;
        private IvFirmEventRepository _firmEventRepository;


        public vFirmEventsController(IvFirmEventRepository firmEventRepository, ILogger<vFirmEventsController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _firmEventRepository = firmEventRepository;
        }

        [HttpGet("AllFirmEvents")]
        public IActionResult GetAllFirmEvents()
        {
            try
            {
                var firmEventEntities = _firmEventRepository.GetAllFirmEvents();
                var results = Mapper.Map<IEnumerable<vFirmEventDto>>(firmEventEntities);

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
