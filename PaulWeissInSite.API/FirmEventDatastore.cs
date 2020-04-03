using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaulWeissInSite.API.Models;

namespace PaulWeissInSite.API
{
    public class FirmEventDatastore
    {
        public static FirmEventDatastore current { get; } = new FirmEventDatastore();

        public List<FirmEventDto> FirmEvents { get; set; }

        public FirmEventDatastore()
        {
            FirmEvents = new List<FirmEventDto>()
            {
                new FirmEventDto()
                    {
                    Id =123,
                    MonthNameShort ="APR",
                    Day ="7",
                    Title ="Financing and Securities Groups Cocktail Reception  [Contact - Claire DeCampo]",
                    TitleSummary ="Financing and Securities Groups Cocktail Reception  [Contact - Claire DeCampo]",
                    SortOrder =1
                },
                new FirmEventDto()
                    {
                    Id =456,
                    MonthNameShort ="APR",
                    Day ="8",
                    Title ="Hong Kong Holiday:  Good Friday",
                    TitleSummary ="Hong Kong Holiday:  Good Friday",
                    SortOrder =2
                }
            };
        }
    }
}
