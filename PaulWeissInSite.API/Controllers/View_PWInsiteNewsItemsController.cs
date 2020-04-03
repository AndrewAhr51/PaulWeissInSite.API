using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaulWeissInSite.API.Models;
using PaulWeissInSite.API.Services;

namespace PaulWeissInSite.API.Controllers
{
    [Route("api/")]
    public class View_PWInsiteNewsItemsController : Controller
    {
        private ILogger<View_PWInsiteNewsItemsController> _logger;
        private IMailService _mailService;
        private IView_PWInsiteNewsItemsRepository _newsItemsRepository;


        public View_PWInsiteNewsItemsController(IView_PWInsiteNewsItemsRepository newsItemsRepository, ILogger<View_PWInsiteNewsItemsController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
            _newsItemsRepository = newsItemsRepository;
        }

        [HttpGet("NewsItems")]
        public IActionResult GetNewsItems()
        {
            try
            {
                var newsEventEntities = _newsItemsRepository.GetNewsItems();
                var results = new List<View_PWInsiteNewsItemsDto>();
                var prevID = 0;

                foreach (var newsEventEntity in newsEventEntities)
                {
                    if (prevID != newsEventEntity.ID)
                    {
                        results.Add(new View_PWInsiteNewsItemsDto
                        {
                            ID = newsEventEntity.ID,
                            PubDate = newsEventEntity.PubDate,
                            NotesUNID = newsEventEntity.NotesUNID,
                            Title = newsEventEntity.Title,
                            BodyHtml = newsEventEntity.BodyHtml,
                            HomePageSection = newsEventEntity.HomePageSection,
                            HomePageSeq = newsEventEntity.HomePageSeq,
                            RunDate1 = newsEventEntity.RunDate1,
                            RunDate2 = newsEventEntity.RunDate2,
                            RunDate3 = newsEventEntity.RunDate3,
                            NotesHash = newsEventEntity.NotesHash,
                            MartSubcategory = newsEventEntity.MartSubcategory,
                            MartForSaleIcon = newsEventEntity.MartForSaleIcon,
                            PWNewImageFileName = newsEventEntity.PWNewImageFileName,
                            BodyTextOnly = newsEventEntity.BodyTextOnly
                        });
                    }
                    prevID = newsEventEntity.ID;
                }

                return Ok(results);

                //return Ok(FirmEventDatastore.current.FirmEvents);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving News Items.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("LeadContent")]
        public IActionResult GetLeadContent()
        {
            try
            {
                var leadContentEntities = _newsItemsRepository.GetLeadNews();
                var results = new List<View_PWInsiteNewsItemsDto>();
                var prevID = 0;

                foreach (var leadContentEntity in leadContentEntities)
                {
                    if (prevID != leadContentEntity.ID)
                    {
                        results.Add(new View_PWInsiteNewsItemsDto
                        {
                            ID = leadContentEntity.ID,
                            PubDate = leadContentEntity.PubDate,
                            NotesUNID = leadContentEntity.NotesUNID,
                            Title = leadContentEntity.Title,
                            BodyHtml = leadContentEntity.BodyHtml,
                            HomePageSection = leadContentEntity.HomePageSection,
                            HomePageSeq = leadContentEntity.HomePageSeq,
                            RunDate1 = leadContentEntity.RunDate1,
                            RunDate2 = leadContentEntity.RunDate2,
                            RunDate3 = leadContentEntity.RunDate3,
                            NotesHash = leadContentEntity.NotesHash,
                            MartSubcategory = leadContentEntity.MartSubcategory,
                            MartForSaleIcon = leadContentEntity.MartForSaleIcon,
                            PWNewImageFileName = leadContentEntity.PWNewImageFileName,
                            BodyTextOnly = leadContentEntity.BodyTextOnly
                        });
                    }
                    prevID = leadContentEntity.ID;
                }

                return Ok(results);

                //return Ok(FirmEventDatastore.current.FirmEvents);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occurred while retrieving Lead Content Items.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

    }
}
