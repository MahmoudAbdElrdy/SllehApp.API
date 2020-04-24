using System;
using System.Collections.Generic;

namespace BackEnd.API.Models
{
    public partial class City
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid CountryId { get; set; }
        public int Order { get; set; }
        public bool? Available { get; set; }

        public virtual Country Country { get; set; }
    }
}
