using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaulWeissInSite.API.Models
{
    public class vFirmEventDto
    {
        public decimal ID { get; set; }
        public string MonthNameShort { get; set; }
        public string Day { get; set; }
        public string Title { get; set; }
        public string TitleSummary { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string IsFirmHoliday { get; set; }
        public string Location { get; set; }
        public string NotesUNID { get; set; }
        public string PWOffice { get; set; }
        public string RecordHash { get; set; }
        public Int64 SortOrder { get; set; }
    }
}
