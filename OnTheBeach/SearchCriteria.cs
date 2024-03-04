using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach
{
    public class SearchCriteria
    {
        public string DepartingFrom { get; set; }
        public IAirportGroupProvider DepartingFromGroup { get; set; }
        public string TravelingTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration { get; set; }
    }
}
