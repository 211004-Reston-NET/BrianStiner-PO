using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class CustomerOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrdersId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Orders { get; set; }
    }
}
