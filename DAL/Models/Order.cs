using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            Chat = new HashSet<Chat>();
        }

        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? MapLatitude { get; set; }
        public decimal? MapLangitude { get; set; }
        public int? Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Workshop Workshop { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
    }
}
