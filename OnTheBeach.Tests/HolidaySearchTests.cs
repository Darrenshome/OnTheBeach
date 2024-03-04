using Moq;
using OnTheBeach.DAL;
using OnTheBeach.Interfaces;

namespace OnTheBeach.Tests
{
    public class HolidaySearchTests
    {
        [Theory]
        [InlineData("MAN", "2023/07/01", 7, "AGP", 2, 9)]
        [InlineData("LONDON", "2023/06/15", 10, "PMI", 6, 5)]
        [InlineData("ANY", "2022/11/10", 14, "LPA", 7, 6)]
        public void HolidaySearch_ShouldFindCorrectFlightAndHotel(string departingFrom, string departureDate, int duration, string travellingTo, int expectedFlightId, int expectedHotelId)
        {
            var searchCriteria = new SearchCriteria{
                DepartingFrom = departingFrom, DepartureDate = DateTime.Parse(departureDate), Duration = duration, TravelingTo = travellingTo
            };

            var holidaySearch = new HolidaySearch(new MockDataProvider());
            var holidays = holidaySearch.FindMatchingHolidays(searchCriteria);

            Assert.NotEmpty(holidays);
            Assert.Equal(expectedFlightId, holidays[0].Flight.Id);
            Assert.Equal(expectedHotelId, holidays[0].Hotel.Id);
        }

        [Fact]
        public void BasicFirstTest()
        {
            var searchCriteria = new SearchCriteria
            {
                DepartingFrom = "MAN",
                TravelingTo = "AGP",
                DepartureDate = DateTime.Parse("2023/07/01"),
                Duration = 7
            };

            var holidaySearch = new HolidaySearch(new MockDataProvider());
            var holidays = holidaySearch.FindMatchingHolidays(searchCriteria);

            Assert.NotEmpty(holidays);
            var firstResult = holidays.First();

            Assert.Equal(826, firstResult.TotalPrice);
            Assert.Equal(2, firstResult.Flight.Id);
            Assert.Equal("MAN", firstResult.Flight.From);
            Assert.Equal("AGP", firstResult.Flight.To);
            Assert.Equal(245, firstResult.Flight.Price);
            Assert.Equal(9, firstResult.Hotel.Id);
            Assert.Equal("Nh Malaga", firstResult.Hotel.Name);
            Assert.Equal(83, firstResult.Hotel.PricePerNight);
        }

        [Fact]
        public void HolidaySearch_Returns_Correct_Holidays_Based_On_Criteria()
        {
            // Arrange
            var mockDataProvider = new Mock<IDataProvider>();
            var searchCriteria = new SearchCriteria
            {
                DepartingFrom = "LONDON",
                TravelingTo = "ANY",
                DepartureDate = new DateTime(2023, 6, 15),
                Duration = 10
            };

            var flights = new List<Flight>
            {
                new Flight { Id = 1, From = "LHR", To = "PMI", DepartureDate = new DateTime(2023, 6, 15), Price = 200 },
            };

            var hotels = new List<Hotel>
            {
                new Hotel { Id = 1, LocalAirports = new List<string> { "PMI" }, ArrivalDate = new DateTime(2023, 6, 15), Nights = 10, PricePerNight = 100 },
            };

            mockDataProvider.Setup(p => p.GetFlights()).Returns(flights);
            mockDataProvider.Setup(p => p.GetHotels()).Returns(hotels);

            var holidaySearch = new HolidaySearch(mockDataProvider.Object);
            var holidays = holidaySearch.FindMatchingHolidays(searchCriteria);

            // Act
            var results = holidays;

            // Assert
            Assert.NotEmpty(results);
            Assert.Contains(results, h => h.Flight.Id == 1 && h.Hotel.Id == 1);
        }
    }
}
