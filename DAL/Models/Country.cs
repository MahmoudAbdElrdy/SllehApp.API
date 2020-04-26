using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public string CountryName { get; set; }
        public Guid CountryId { get; set; }
        public int Order { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
