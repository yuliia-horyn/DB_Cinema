using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class ShowSeat
    {
        public int ShowSeatId { get; set; }
        public decimal? Price { get; set; }
        public int? CinemaSeatId { get; set; }
        public int? ShowId { get; set; }
        public int? TicketId { get; set; }

        public virtual CinemaSeat CinemaSeat { get; set; }
        public virtual Show Show { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
