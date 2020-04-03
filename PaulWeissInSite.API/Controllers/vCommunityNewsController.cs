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
    public class vCommunityNewsController : Controller
    {
        private ILogger<vCommunityNewsController> _logger;
        private IMailService _mailService;
        private IvCommunityNewsRepository _communityNewsRepository;


        public vCommunityNewsController(IvCommunityNewsRepository vCommunityNewsRepository, ILogger<vCommunityNewsController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _communityNewsRepository = vCommunityNewsRepository;
        }
        [HttpGet("CommunityNews")]
        public IActionResult GetCommunityNews()
        {
            try
            {
                var communityNewsEntities = _communityNewsRepository.GetCommunityNews();
                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<vCommunityNewsDto>>(communityNewsEntities);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving News Items.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("CommunityAnnouncements")]
        public IActionResult GetCommunityAnnouncements()
        {
            try
            {
                var communityNewsEntities = _communityNewsRepository.GetCommunityAnnouncements();
                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<vCommunityNewsDto>>(communityNewsEntities);
                
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Announcements Items.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("CommunityReminders")]
        public IActionResult GetCommunityReminders()
        {
            try
            {
                var communityNewsEntities = _communityNewsRepository.GetCommunityReminders();
                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<vCommunityNewsDto>>(communityNewsEntities);
                
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Reminder Items.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("CommunityTheMart")]
        public IActionResult GetCommunityMart()
        {
            try
            {
                var communityNewsEntities = _communityNewsRepository.GetCommunityMart();
                //Automapper is configured in the Startup...
                var results = Mapper.Map<IEnumerable<vCommunityNewsDto>>(communityNewsEntities);
                
                return Ok(results);
                
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Mart Items.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }
    }
}
