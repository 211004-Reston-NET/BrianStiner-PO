using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class Order
    {
        public int Id { get; set; }
        public decimal? Total { get; set; }
        public string Location { get; set; }
    }
}
