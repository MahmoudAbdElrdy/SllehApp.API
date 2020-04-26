using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class CountryVM
    {
        //public Country()
        //{
        //    City = new HashSet<City>();
        //}

        public string CountryName { get; set; }
        public Guid CountryId { get; set; } = Guid.NewGuid();
        public int Order { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public bool? Available { get; set; } = true;

        //public virtual ICollection<CityVM> City { get; set; }
    }
}
