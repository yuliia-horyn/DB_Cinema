using System;


namespace DTO
{
    public class ShowDTO
    {
        public int ShowID { get; set; }
        public DateTime Date { get; set; }      
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MovieID { get; set; }
        public int CinemaHallID { get; set; }
        public override string ToString()
        {
            return $"{ShowID,-3}*\t{Date,-20}*\t{StartTime,-20}* {EndTime,-20}*\t{MovieID,-3}*\t{CinemaHallID,-3}*";
        }
    }
}
