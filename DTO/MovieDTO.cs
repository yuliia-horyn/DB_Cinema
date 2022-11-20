using System;

namespace DTO
{
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }        
        public override string ToString()
        {
            return $"{MovieID,-3}*\t{Title,-25}*\t{Duration,-20}* {Language,-15}*\t{ReleaseDate,-20}*\t{Country,-15}* {Genre,-10} *";
        }
    }
}
