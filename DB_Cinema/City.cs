using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class City
    {
        public City()
        {
            Cinemas = new HashSet<Cinema>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}
