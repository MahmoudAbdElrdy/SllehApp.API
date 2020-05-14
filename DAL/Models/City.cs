using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class City
    {
        public City()
        {
            Workshop = new HashSet<Workshop>();
        }

        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid CountryId { get; set; }
        public int Order { get; set; }
        public bool? Available { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Workshop> Workshop { get; set; }
    }
}
