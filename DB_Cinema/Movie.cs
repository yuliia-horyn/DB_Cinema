using System;
using System.Collections.Generic;

#nullable disable

namespace DB_Cinema
{
    public partial class Movie
    {
        public Movie()
        {
            Shows = new HashSet<Show>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Language { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}
