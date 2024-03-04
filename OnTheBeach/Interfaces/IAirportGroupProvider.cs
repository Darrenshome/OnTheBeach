using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach.Interfaces
{
    public interface IAirportGroupProvider
    {
        IEnumerable<string> GetAirports();
    }
}
