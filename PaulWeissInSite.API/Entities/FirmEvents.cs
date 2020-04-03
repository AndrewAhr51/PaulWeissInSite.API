using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaulWeissInSite.API.Entities
{
    public class FirmEvents
    {
        [Key]
        public int Id { get; set; }
        public string MonthNameShort { get; set; }
        public string Day { get; set; }
        public string Title { get; set; }
        public string TitleSummary { get; set; }
        public int SortOrder { get; set; }
    }
}
