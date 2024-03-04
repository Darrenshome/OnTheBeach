using OnTheBeach.DAL;
using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach.Tests
{
    public class HotelTests
    {
        [Fact]
        public void LoadHotels_Count13()
        {
            IDataProvider data = new MockDataProvider();
            var hotels = data.GetHotels();

            Assert.True(hotels.Count == 13);
        }
    }
}
