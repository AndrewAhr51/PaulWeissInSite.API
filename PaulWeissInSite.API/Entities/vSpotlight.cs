
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaulWeissInSite.API.Entities
{
    public class vSpotlight
    {
        [Key]
        public int Id { get; set; }
        public string Body1 { get; set; }
        public string Title { get; set; }

    }
}
