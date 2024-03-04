using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach.Interfaces
{
    public interface IDataProvider
    {
        List<Flight> GetFlights();
        List<Hotel> GetHotels();
    }
}
