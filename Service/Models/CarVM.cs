using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class CarVM
    {
        //public Car()
        //{
        //    WorkshopCar = new HashSet<WorkshopCar>();
        //}

        public Guid CarId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual ICollection<WorkshopCarVM> WorkshopCar { get; set; }
    }
}
