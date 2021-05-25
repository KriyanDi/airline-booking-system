using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public interface IRetrieveInformation
    {
        List<Flight> FindAvailableFlights(string orig, string dest);

        void DisplaySystemDetails();
    }
}