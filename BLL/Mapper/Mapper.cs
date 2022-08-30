using BLL.Entities;
using DAL.Entities;

namespace BLL
{
    public class Mapper
    {
        public ShowDTO ShowDTO
        {
            get => default;
            set
            {
            }
        }

        public static Show ToDAL(ShowDTO show)
        {
            return new Show()
            {
                Id = show.Id,
                Name = show.Name,
                Author = show.Author,
                Date = show.Date,
                Genre = show.Genre,
                Price = show.Price,
                FreePlaces = show.FreePlaces
            };
        }

        public static ShowDTO ToBLL(Show show)
        {
            return new ShowDTO()
            {
                Id = show.Id,
                Name = show.Name,
                Author = show.Author,
                Date = show.Date,
                Genre = show.Genre,
                Price = show.Price,
                FreePlaces = show.FreePlaces
            };
        }

        public static List<ShowDTO> ToBLL(List<Show> shows)
        {
            List<ShowDTO> showDTOs = new List<ShowDTO>();

            foreach(var show in shows)
            {
                showDTOs.Add(ToBLL(show));
            }

            return showDTOs;
        }
    }
}
