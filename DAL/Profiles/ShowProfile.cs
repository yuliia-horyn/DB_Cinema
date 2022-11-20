using AutoMapper;
using DB_Cinema;
using DTO;

namespace DAL.Profiles
{
    public class ShowProfile: Profile
    {
        public ShowProfile()
        {
           CreateMap<Show, ShowDTO>().ReverseMap();
        }
    }
}
