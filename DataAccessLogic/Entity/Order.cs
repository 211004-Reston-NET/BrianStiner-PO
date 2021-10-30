using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class Order
    {
        public Order()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
            OrdersLineitems = new HashSet<OrdersLineitem>();
            StorefrontOrders = new HashSet<StorefrontOrder>();
        }

        public int Id { get; set; }
        public decimal? Total { get; set; }
        public string Location { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<OrdersLineitem> OrdersLineitems { get; set; }
        public virtual ICollection<StorefrontOrder> StorefrontOrders { get; set; }
    }
}
