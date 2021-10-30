using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class LineItem
    {
        public LineItem()
        {
            Inventories = new HashSet<Inventory>();
            OrdersLineitems = new HashSet<OrdersLineitem>();
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrdersLineitem> OrdersLineitems { get; set; }
    }
}
