namespace AirlineBookingSystem
{
    public interface IRetrieveInformation
    {
        void FindAvailableFlights(string orig, string dest);

        void DisplaySystemDetails();
    }
}