using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach
{
    public class Holiday
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }

        public decimal TotalPrice => Flight.Price + (Hotel.PricePerNight * Hotel.Nights);

        public Holiday(Flight flight, Hotel hotel)
        {
            Flight = flight;
            Hotel = hotel;
        }
    }
}
