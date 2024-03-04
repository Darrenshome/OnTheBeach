using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnTheBeach.DAL
{
    public class MockDataProvider : IDataProvider
    {
        private const string FlightsFilePath = "Assets/Flights.json";
        private const string HotelsFilePath = "Assets/Hotels.json";

        public List<Flight> GetFlights()
        {
            var flightsJson = File.ReadAllText(FlightsFilePath);
            var flights = JsonSerializer.Deserialize<List<Flight>>(flightsJson);
            return flights ?? new List<Flight>();
        }

        public List<Hotel> GetHotels()
        {
            var hotelsJson = File.ReadAllText(HotelsFilePath);
            var hotels = JsonSerializer.Deserialize<List<Hotel>>(hotelsJson);
            return hotels ?? new List<Hotel>();
        }
    }
}
