using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IMovieDal
    {
        List<MovieDTO> GetAllMovies();
        MovieDTO CreateMovie(MovieDTO movie);
        MovieDTO UpdateMovie(MovieDTO movie);
        MovieDTO DeleteMovie(MovieDTO movie);
    }
}
