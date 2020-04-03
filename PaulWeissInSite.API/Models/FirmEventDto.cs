using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaulWeissInSite.API.Models
{
    public class FirmEventDto
    {
        public int Id { get; set; }
        public string MonthNameShort { get; set; }
        public string Day { get; set; }
        public string Title { get; set; }
        public string TitleSummary { get; set; }
        public int SortOrder { get; set; }
    }
}
