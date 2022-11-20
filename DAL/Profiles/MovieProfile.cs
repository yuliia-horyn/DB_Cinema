using AutoMapper;
using DB_Cinema;
using DTO;

namespace DAL.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }

    }
}
