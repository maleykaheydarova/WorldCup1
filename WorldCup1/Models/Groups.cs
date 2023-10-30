using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldCup1.Models
{
    public class Groups : BaseModel
    {
        public string Name { get; set; }
        public int CountryCount { get; set; } = DefaultConstants.DEFAULT_GROUP_COUNTRY_COUNT;
        public List<Country> Countries { get; set; }

        public Groups()
        {
            Countries = new List<Country>();
        }
    }
}