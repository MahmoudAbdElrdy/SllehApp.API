using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Car
    {
        public Car()
        {
            WorkshopCar = new HashSet<WorkshopCar>();
        }

        public Guid CarId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<WorkshopCar> WorkshopCar { get; set; }
    }
}
