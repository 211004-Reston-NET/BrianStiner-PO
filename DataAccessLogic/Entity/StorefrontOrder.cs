using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class StorefrontOrder
    {
        public int? StorefrontId { get; set; }
        public int? OrdersId { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Storefront Storefront { get; set; }
    }
}
