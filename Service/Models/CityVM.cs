using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class CityVM
    {
        public Guid CityId { get; set; } = Guid.NewGuid();
        public string CityName { get; set; }
        public Guid CountryId { get; set; }
        public int Order { get; set; }
        public bool? Available { get; set; } = true;
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual CountryVM Country { get; set; }
    }
}
