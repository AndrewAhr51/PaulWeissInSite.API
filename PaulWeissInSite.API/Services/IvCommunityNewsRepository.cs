﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Entities;

namespace PaulWeissInSite.API.Services
{
    public interface IvCommunityNewsRepository
    {
        IEnumerable<vCommunityNews> GetCommunityNews();

        IEnumerable<vCommunityNews> GetCommunityAnnouncements();

        IEnumerable<vCommunityNews> GetCommunityReminders();

        IEnumerable<vCommunityNews> GetCommunityMart();

    }
}