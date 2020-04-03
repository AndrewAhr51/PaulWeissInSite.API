using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaulWeissInSite.API.Entities
{
    public class vRecentHires
    {
        [Key]
        public string RecordID { get; set; }
        public string AccountName { get; set; }
        public string Department { get; set; }
        public string DisplayField { get; set; }
        public string Ext { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string ImageID { get; set; }
        public string JobTitle { get; set; }
        public string LastName { get; set; }
        public string LoginID { get; set; }
        public string Office { get; set; }
        public string Phone { get; set; }
        public Byte  []PictureURL { get; set; }
        public string PreferredName { get; set; }
        public Int32 RecentHire { get; set; }
       
        public string Room { get; set; }
        public string UserName { get; set; }

    }
}
