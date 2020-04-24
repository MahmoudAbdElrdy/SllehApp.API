using System;
using System.Collections.Generic;

namespace BackEnd.API.Models
{
    public partial class Workshop
    {
        public Workshop()
        {
            Order = new HashSet<Order>();
            RateWorkshop = new HashSet<RateWorkshop>();
            WorkshopCar = new HashSet<WorkshopCar>();
            WorkshopFeatures = new HashSet<WorkshopFeatures>();
            WorkshopMalfunction = new HashSet<WorkshopMalfunction>();
            WorkshopNotifications = new HashSet<WorkshopNotifications>();
            WorkshopTechnician = new HashSet<WorkshopTechnician>();
            WorkshopWorkTime = new HashSet<WorkshopWorkTime>();
        }

        public Guid WorkshopId { get; set; }
        public string Name { get; set; }
        public bool? IsTrust { get; set; }
        public string ImageUrl { get; set; }
        public string MapLatitude { get; set; }
        public string MapLangitude { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public string OwnerName { get; set; }
        public string OwnerImage { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? HasSparePart { get; set; }
        public bool? HasWarranty { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<RateWorkshop> RateWorkshop { get; set; }
        public virtual ICollection<WorkshopCar> WorkshopCar { get; set; }
        public virtual ICollection<WorkshopFeatures> WorkshopFeatures { get; set; }
        public virtual ICollection<WorkshopMalfunction> WorkshopMalfunction { get; set; }
        public virtual ICollection<WorkshopNotifications> WorkshopNotifications { get; set; }
        public virtual ICollection<WorkshopTechnician> WorkshopTechnician { get; set; }
        public virtual ICollection<WorkshopWorkTime> WorkshopWorkTime { get; set; }
    }
}
