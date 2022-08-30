using DAL.Entities;
using DAL.Repositories;

namespace Tests
{
    public class RepositoryTest
    {
        private readonly ShowRepository showRepository;

        public RepositoryTest()
        {
            showRepository = new ShowRepository();
        }

        [Fact]
        public void GetShow_ShouldReturnAllShows()
        {
            // Arrange
            var shows = new List<Show>();

            // Act
            shows = showRepository.GetAll();

            // Assert
            Assert.NotNull(shows);
        }
    }
}