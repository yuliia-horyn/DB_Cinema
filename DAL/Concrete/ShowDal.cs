using AutoMapper;
using DAL.Interfaces;
using DB_Cinema;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    public class ShowDal : IShowDal
    {
        private readonly IMapper _mapper;
        public ShowDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ShowDTO CreateShow(ShowDTO show)
        {
            using (var entites = new cinemasContext())
            {
                var showInDB = _mapper.Map<Show>(show);
                showInDB.ShowId = show.ShowID;
                entites.Shows.Add(showInDB);
                entites.SaveChanges();
                return _mapper.Map<ShowDTO>(showInDB);
            }
        }

        public ShowDTO DeleteShow(ShowDTO show)
        {
            using (var entites = new cinemasContext())
            {
                var showInDB = _mapper.Map<Show>(show);
                showInDB = entites.Shows.SingleOrDefault(x => x.ShowId == show.ShowID);
                if (showInDB != null)
                {
                    entites.Shows.Remove(showInDB);
                    entites.SaveChanges();
                    return _mapper.Map<ShowDTO>(showInDB);
                }
                return null;
            }
        }

        public List<ShowDTO> GetAllShows()
        {
            using (var entities = new cinemasContext())
            {
                var shows = entities.Shows.Where(x => x.ShowId != 0).ToList();
                return _mapper.Map<List<ShowDTO>>(shows);
            }
        }

        public ShowDTO UpdateShow(ShowDTO show)
        {
            using (var entites = new cinemasContext())
            {
                var showInDB = _mapper.Map<Show>(show);
                showInDB = entites.Shows.SingleOrDefault(x => x.ShowId == show.ShowID);
                if (showInDB != null)
                {
                    showInDB.Date = show.Date;
                    showInDB.StartTime = show.StartTime;
                    showInDB.EndTime = show.EndTime;
                    showInDB.MovieId= show.MovieID;
                    showInDB.CinemaHallId = show.CinemaHallID;
                    entites.SaveChanges();
                    return _mapper.Map<ShowDTO>(showInDB);
                }
                return null;
            }
        }
    }
}

