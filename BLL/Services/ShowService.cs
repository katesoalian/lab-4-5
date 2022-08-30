using BLL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class ShowService : Mapper
    {
        ShowRepository showRepository = new ShowRepository();

        public void AddShow(ShowDTO show)
        {
            showRepository.AddShow(Mapper.ToDAL(show));
        }

        public List<ShowDTO> GetAll()
        {
            return Mapper.ToBLL(showRepository.GetAll());
        }

        public ShowDTO GetShowById(int id)
        {
            ShowDTO showDTO = Mapper.ToBLL(showRepository.GetAll().Find(show => show.Id == id));

            return showDTO;
        }

        public void UpdateShow(ShowDTO show)
        {
            showRepository.UpdateShow(Mapper.ToDAL(show));
        }
    }
}
