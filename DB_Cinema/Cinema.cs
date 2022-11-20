using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class Cinema
    {
        public Cinema()
        {
            CinemaHalls = new HashSet<CinemaHall>();
        }

        public int CinemaId { get; set; }
        public string Name { get; set; }
        public int? QuantityOfCinemaHalls { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<CinemaHall> CinemaHalls { get; set; }
    }
}
