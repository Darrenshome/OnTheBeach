using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach.AirportGroupProviders
{
    public class LondonAirportsProvider : IAirportGroupProvider
    {
        public IEnumerable<string> GetAirports() => new List<string> { "LHR", "LGW", "LCY", "STN", "LTN" };
    }
}
