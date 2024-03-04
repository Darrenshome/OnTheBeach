using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach.AirportGroupProviders
{
    public class MidlandsAirportsProvider : IAirportGroupProvider
    {
        public IEnumerable<string> GetAirports() => new List<string> { "BHX", "EMA", "DSA" };
    }

}
