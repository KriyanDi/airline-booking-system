using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class SystemManager
    {
        #region Fields
        private List<Airport> _airports;

        #endregion

        #region Constructors
        public SystemManager()
        {
            _airports = new List<Airport>();
        }
        #endregion

        #region Properties
        public List<Airport> Airports
        {
            get
            {
                List<Airport> airportCopy = null;

                if (_airports != null)
                {
                    airportCopy = new List<Airport>();
                    for (int i = 0; i < _airports.Count; i++)
                    {
                        airportCopy.Add(new Airport(_airports[i]));
                    }
                }

                return airportCopy;
            }
        }

        #endregion

        #region Methods
        public void CreateAirport(string airportName)
        {
            if (!DoesAirportExist(airportName))
            {
                _airports.Add(new Airport(airportName));
            }
            else
            {
                throw new ArgumentException($"Airport {airportName} already exists!");
            }
        }


        //public void CreateAirline(string n);
        //public void CreateFlight(string aname, string orig, string dest, int year, int month, int day, string id);
        //public void CreateSection(string air, string flId, int rows, int cols, SeatClass s);
        //public void FindAvailableFlights(string orig, string dest);
        //public void BookSeat(string air, string fl, SeatClass s, int row, char col);
        //public void DisplaySystemDetails();
        #endregion

        #region Help Methods
        private bool DoesAirportExist(string airportName)
        {
            bool exists = false;

            foreach (Airport airport in _airports)
            {
                if (airport.Name == airportName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }
        #endregion
    }
}
