using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaulWeissInSite.API.Models
{
    public class View_PWInsiteNewsItemsDto
    {
        public Int32 ID { get; set; }
        public DateTime PubDate { get; set; }
        public string NotesUNID { get; set; }
        public string Title { get; set; }
        public string BodyHtml { get; set; }
        public string HomePageSection { get; set; }
        public Int32 HomePageSeq { get; set; }
        public DateTime? RunDate1 { get; set; }
        public DateTime? RunDate2 { get; set; }
        public DateTime? RunDate3 { get; set; }
        public string NotesHash { get; set; }
        public string MartSubcategory { get; set; }
        public string MartForSaleIcon { get; set; }
        public string PWNewImageFileName { get; set; }
        public string BodyTextOnly { get; set; }
    }
}
