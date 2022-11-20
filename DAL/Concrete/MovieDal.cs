using AutoMapper;
using DAL.Interfaces;
using DB_Cinema;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    public class MovieDal: IMovieDal
    {
        private readonly IMapper _mapper;
        public MovieDal(IMapper mapper)
        {
            _mapper = mapper;
        }
        public MovieDTO CreateMovie(MovieDTO movie)
        {

            using (var entites = new cinemasContext())
            {
                var movieInDB = _mapper.Map<Movie>(movie);
                 movieInDB.MovieId = movie.MovieID;
                entites.Movies.Add(movieInDB);
                 entites.SaveChanges();
                 return _mapper.Map<MovieDTO>(movieInDB);
            }
        }

        public List<MovieDTO> GetAllMovies()
        {
            using (var entities = new cinemasContext())
            {
                var movies = entities.Movies.Where(x => x.MovieId != 0).ToList();
                return _mapper.Map<List<MovieDTO>>(movies);
            }
        }
        public MovieDTO UpdateMovie(MovieDTO movie)
        {
            using (var entites = new cinemasContext())
            {
                var movieInDB = _mapper.Map<Movie>(movie);
                movieInDB = entites.Movies.SingleOrDefault(x => x.MovieId == movie.MovieID);
                if (movieInDB != null)
                {                    
                    movieInDB.Title = movie.Title;
                    movieInDB.Duration = movie.Duration;
                    movieInDB.Language= movie.Language;
                    movieInDB.ReleaseDate = movie.ReleaseDate;
                    movieInDB.Country = movie.Country;
                    movieInDB.Genre = movie.Genre;
                    entites.SaveChanges();
                    return _mapper.Map<MovieDTO>(movieInDB);
                }
                return null;
            }
        }
       
        public MovieDTO DeleteMovie(MovieDTO movie)
        {
            using (var entites = new cinemasContext())
            {
                var movieInDB = _mapper.Map<Movie>(movie);
                movieInDB = entites.Movies.SingleOrDefault(x => x.MovieId == movie.MovieID);
                if (movieInDB != null)
                {
                    entites.Movies.Remove(movieInDB);
                    entites.SaveChanges();
                    return _mapper.Map<MovieDTO>(movieInDB);
                }
                return null;
            }
        }
    }
}
