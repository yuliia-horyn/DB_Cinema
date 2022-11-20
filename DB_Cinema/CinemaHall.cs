using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class CinemaHall
    {
        public CinemaHall()
        {
            CinemaSeats = new HashSet<CinemaSeat>();
            Shows = new HashSet<Show>();
        }

        public int CinemaHallId { get; set; }
        public string Name { get; set; }
        public int? TotalSeats { get; set; }
        public int? CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual ICollection<CinemaSeat> CinemaSeats { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
