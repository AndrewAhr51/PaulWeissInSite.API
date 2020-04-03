using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public class vCommunityNewsRepository: IvCommunityNewsRepository
    {
        private vCommunityNewsContext _context;

        public vCommunityNewsRepository(vCommunityNewsContext context)
        {
            _context = context;
        }

        public IEnumerable<vCommunityNews> GetCommunityNews()
        {
            return _context.vCommunityNews.OrderByDescending(c => c.PubDate)
                .Where(c => c.HomePageSection == "Lead Content")
                .Take(10)
                .ToList();
        }

        public IEnumerable<vCommunityNews> GetCommunityAnnouncements()
        {
            return _context.vCommunityNews.OrderByDescending(c => c.PubDate)
                .Where(c => c.HomePageSection == "Announcements").Take(10)
                .ToList();
        }
        public IEnumerable<vCommunityNews> GetCommunityReminders()
        {
            return _context.vCommunityNews.OrderByDescending(c => c.PubDate)
                .Where(c => c.HomePageSection == "General").Take(10)
                .ToList();
        }

        public IEnumerable<vCommunityNews> GetCommunityMart()
        {
            return _context.vCommunityNews.OrderByDescending(c =>c.PubDate)
                .Where(c => c.HomePageSection == "The Mart"
                        && c.MartSubcategory == "Community News"
                        || c.MartSubcategory=="For Sale")
                .ToList();
        }

    }
}
