using OnTheBeach.Helpers;
using OnTheBeach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeach
{
    public class HolidaySearch
    {
        private List<Flight> flights;
        private List<Hotel> hotels;
        private SearchCriteria criteria;

        public HolidaySearch(IDataProvider dataProvider)
        {
            this.flights = dataProvider.GetFlights();
            this.hotels = dataProvider.GetHotels();
        }

        public List<Holiday> FindMatchingHolidays(SearchCriteria criteria)
        {
            criteria.DepartingFromGroup = AirportGroupProviderHelper.GetAirportGroupProvider(criteria.DepartingFrom);
            
            var matchingHolidays = (from flight in flights
                                    from hotel in hotels
                                    where (criteria.DepartingFrom == "ANY" ||
                                           (criteria.DepartingFromGroup != null && criteria.DepartingFromGroup.GetAirports().Contains(flight.From)) ||
                                           flight.From == criteria.DepartingFrom) &&
                                          hotel.LocalAirports.Contains(flight.To) &&
                                          hotel.ArrivalDate == flight.DepartureDate &&
                                          hotel.Nights == criteria.Duration &&
                                          (criteria.TravelingTo == "ANY" || hotel.LocalAirports.Contains(criteria.TravelingTo))
                                    select new Holiday(flight, hotel))
                        .OrderBy(holiday => holiday.TotalPrice)
                        .ThenBy(holiday => holiday.Flight.From);

            return matchingHolidays.ToList();
        }
    }
}
