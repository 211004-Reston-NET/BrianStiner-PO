using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
