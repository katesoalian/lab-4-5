namespace BLL.Entities
{
    public class ShowDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int FreePlaces { get; set; }

        public ShowDTO()
        {

        }

        public ShowDTO(string name, string author, string genre, string date, int price, int freePlaces)
        {
            Name = name;
            Author = author;
            Genre = genre;
            Date = date;
            Price = price;
            FreePlaces = freePlaces;
        }
    }
}
