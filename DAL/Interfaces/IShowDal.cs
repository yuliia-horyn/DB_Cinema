using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IShowDal
    {
        List<ShowDTO> GetAllShows();
        ShowDTO CreateShow(ShowDTO show);
        ShowDTO UpdateShow(ShowDTO show);
        ShowDTO DeleteShow(ShowDTO show);
    }
}
