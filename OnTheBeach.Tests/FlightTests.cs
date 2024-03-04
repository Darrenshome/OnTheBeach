using OnTheBeach.DAL;
using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach.Tests
{
    public class FlightTests
    {
        [Fact]
        public void LoadFlights_Count12()
        {
            IDataProvider data = new MockDataProvider();
            var flights = data.GetFlights();

            Assert.True(flights.Count == 12);
        }
    }
}
