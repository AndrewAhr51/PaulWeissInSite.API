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
    public class vSpotlightController : Controller
    {
        private ILogger<vSpotlightController> _logger;
        private IMailService _mailService;
        private IvSpotlightRepository _spotlightRepository;

        public vSpotlightController(IvSpotlightRepository vRSpotlightRepository, ILogger<vSpotlightController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _spotlightRepository = vRSpotlightRepository;
        }
        [HttpGet("Spotlight")]
        public IActionResult GetCommunityMart()
        {
            try
            {
                var spotlightEntities = _spotlightRepository.GetSpotlight();

                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<vSpotlightDto>>(spotlightEntities);

                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Paul Weiss InSite Spotlight.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }
    }
}
