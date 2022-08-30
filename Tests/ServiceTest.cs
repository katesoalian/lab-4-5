using BLL.Entities;
using BLL.Services;

namespace Tests
{
    public class ServiceTest
    {
        private readonly ShowService showService;

        public ServiceTest()
        {
            showService = new ShowService();
        }

        [Fact]
        public void GetShow_ShouldReturnShowById_WhenShowExists()
        {
            // Arrange
            var showId = 0;

            // Act
            var show = showService.GetShowById(showId);

            // Assert
            Assert.Equal(showId, show.Id);
        }

        [Fact]
        public void GetShow_ShouldReturnAllShows()
        {
            // Arrange
            var shows = new List<ShowDTO>();

            // Act
            shows = showService.GetAll();

            // Assert
            Assert.NotNull(shows);
        }
    }
}