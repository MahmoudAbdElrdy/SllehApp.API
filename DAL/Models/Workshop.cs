using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Workshop
    {
        public Workshop()
        {
            Chat = new HashSet<Chat>();
            Order = new HashSet<Order>();
            WorkshopCar = new HashSet<WorkshopCar>();
            WorkshopFeatures = new HashSet<WorkshopFeatures>();
            WorkshopMalfunction = new HashSet<WorkshopMalfunction>();
            WorkshopNotifications = new HashSet<WorkshopNotifications>();
            WorkshopRate = new HashSet<WorkshopRate>();
            WorkshopTechnician = new HashSet<WorkshopTechnician>();
            WorkshopWorkTime = new HashSet<WorkshopWorkTime>();
        }

        public Guid WorkshopId { get; set; }
        public string Name { get; set; }
        public bool? IsTrust { get; set; }
        public string ImageUrl { get; set; }
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
        public string Token { get; set; }
        public decimal? MapLatitude { get; set; }
        public decimal? MapLangitude { get; set; }
        public Guid? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<WorkshopCar> WorkshopCar { get; set; }
        public virtual ICollection<WorkshopFeatures> WorkshopFeatures { get; set; }
        public virtual ICollection<WorkshopMalfunction> WorkshopMalfunction { get; set; }
        public virtual ICollection<WorkshopNotifications> WorkshopNotifications { get; set; }
        public virtual ICollection<WorkshopRate> WorkshopRate { get; set; }
        public virtual ICollection<WorkshopTechnician> WorkshopTechnician { get; set; }
        public virtual ICollection<WorkshopWorkTime> WorkshopWorkTime { get; set; }
    }
}
