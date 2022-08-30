using DAL.Entities;
using Newtonsoft.Json;

namespace DAL.Repositories
{
    public class ShowRepository
    {
        private readonly static string path = @"C:\Users\admin\source\repos\Lab4-5\DAL\DataBase\shows.json";
         JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        private string json = File.ReadAllText(path);
        private List<Show> shows = new List<Show>();

        public void AddShow(Show show)
        {
            json = File.ReadAllText(path);
            shows = JsonConvert.DeserializeObject<List<Show>>(json, settings);

            if (shows == null)
            {
                shows = new List<Show>();
                show.Id = 0;
            }
            else
            {
                show.Id = shows.Count;
            }

            shows.Add(show);

            File.WriteAllText(path, JsonConvert.SerializeObject(shows, Formatting.Indented, settings));
        }

        public void DeleteShow(Show show)
        {
            json = File.ReadAllText(path);
            shows = JsonConvert.DeserializeObject<List<Show>>(json, settings);

            shows.RemoveAt(show.Id);

            for (int i = 0; i < shows.Count; i++)
            {
                if (shows[i].Id > show.Id)
                {
                    shows[i].Id--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(shows, Formatting.Indented, settings));
        }

        public List<Show> GetAll()
        {
            json = File.ReadAllText(path);
            shows = JsonConvert.DeserializeObject<List<Show>>(json, settings);

            if (shows == null)
                shows = new List<Show>();

            return shows;
        }

        public void UpdateShow(Show show)
        {
            json = File.ReadAllText(path);
            shows = JsonConvert.DeserializeObject<List<Show>>(json, settings);

            shows[show.Id] = show;

            File.WriteAllText(path, JsonConvert.SerializeObject(shows, Formatting.Indented, settings));
        }
    }
}
