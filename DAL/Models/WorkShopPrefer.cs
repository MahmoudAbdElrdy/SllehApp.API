using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class WorkShopPrefer
    {
        public Guid WorkShopPreferId { get; set; }
        public Guid WorkShopId { get; set; }
        public Guid CustomerId { get; set; }
        public bool? Prefer { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Workshop WorkShop { get; set; }
    }
}
