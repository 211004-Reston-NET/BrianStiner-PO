using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class Inventory
    {
        public int? StorefrontId { get; set; }
        public int? LineitemId { get; set; }

        public virtual LineItem Lineitem { get; set; }
        public virtual Storefront Storefront { get; set; }
    }
}
