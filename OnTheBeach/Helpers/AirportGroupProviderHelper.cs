using OnTheBeach.AirportGroupProviders;
using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach.Helpers
{
    public static class AirportGroupProviderHelper
    {
        public static IAirportGroupProvider GetAirportGroupProvider(string departingFrom)
        {
            switch (departingFrom.ToUpper())
            {
                case "LONDON":
                    return new LondonAirportsProvider();
                case "ANY":
                    return null;
                default:
                    return null; // default provider.
            }
        }
    }
}
