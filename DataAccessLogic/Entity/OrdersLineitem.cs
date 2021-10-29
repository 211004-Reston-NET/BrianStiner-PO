using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class OrdersLineitem
    {
        public int? OrdersId { get; set; }
        public int? LineItemId { get; set; }

        public virtual LineItem LineItem { get; set; }
        public virtual Order Orders { get; set; }
    }
}
