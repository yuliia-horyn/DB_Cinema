using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class CinemaSeat
    {
        public CinemaSeat()
        {
            ShowSeats = new HashSet<ShowSeat>();
        }

        public int CinemaSeatId { get; set; }
        public int? SeatNumber { get; set; }
        public int? CinemaHallId { get; set; }

        public virtual CinemaHall CinemaHall { get; set; }
        public virtual ICollection<ShowSeat> ShowSeats { get; set; }
    }
}
