using System;
using System.Collections.Generic;

namespace BackEnd.API.Models
{
    public partial class WorkshopCar
    {
        public Guid WorkshopCarId { get; set; }
        public Guid? CarId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Car Car { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}
