using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
