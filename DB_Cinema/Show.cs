using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class Show
    {
        public Show()
        {
            ShowSeats = new HashSet<ShowSeat>();
            Tickets = new HashSet<Ticket>();
        }

        public int ShowId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? MovieId { get; set; }
        public int? CinemaHallId { get; set; }

        public virtual CinemaHall CinemaHall { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<ShowSeat> ShowSeats { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
