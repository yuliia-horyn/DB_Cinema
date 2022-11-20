using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class Ticket
    {
        public Ticket()
        {
            ShowSeats = new HashSet<ShowSeat>();
            Users = new HashSet<User>();
        }

        public int TicketId { get; set; }
        public DateTime? Data { get; set; }
        public int? ShowId { get; set; }

        public virtual Show Show { get; set; }
        public virtual ICollection<ShowSeat> ShowSeats { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
