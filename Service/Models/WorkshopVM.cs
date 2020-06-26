using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopVM
    {
        //public Workshop()
        //{
        //    Order = new HashSet<Order>();
        //    WorkshopCar = new HashSet<WorkshopCar>();
        //    WorkshopFeatures = new HashSet<WorkshopFeatures>();
        //    WorkshopMalfunction = new HashSet<WorkshopMalfunction>();
        //    WorkshopNotifications = new HashSet<WorkshopNotifications>();
        //    WorkshopRate = new HashSet<WorkshopRate>();
        //    WorkshopTechnician = new HashSet<WorkshopTechnician>();
        //    WorkshopWorkTime = new HashSet<WorkshopWorkTime>();
        //}

        public Guid WorkshopId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public bool? IsTrust { get; set; } = false;
        public string ImageUrl { get; set; }
        public string Token { get; set; }
        public decimal? MapLatitude { get; set; } = 0.0m;
        public decimal? MapLangitude { get; set; } = 0.0m;
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public string OwnerName { get; set; }
        public string OwnerImage { get; set; }
        public bool? IsAvailable { get; set; } = true;
        public bool? HasSparePart { get; set; }
        public bool? HasWarranty { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public Guid? CityId { get; set; }
        public bool? Prefer { get; set; } = false;        //public virtual ICollection<OrderVM> Order { get; set; }
        //public virtual ICollection<WorkshopCarVM> WorkshopCar { get; set; }
        //public virtual ICollection<WorkshopFeaturesVM> WorkshopFeatures { get; set; }
        //public virtual ICollection<WorkshopMalfunctionVM> WorkshopMalfunction { get; set; }
        //public virtual ICollection<WorkshopNotificationsVM> WorkshopNotifications { get; set; }
        //public virtual ICollection<WorkshopRateVM> WorkshopRate { get; set; }
        //public virtual ICollection<WorkshopTechnicianVM> WorkshopTechnician { get; set; }
        //public virtual ICollection<WorkshopWorkTimeVM> WorkshopWorkTime { get; set; }
    }
}
