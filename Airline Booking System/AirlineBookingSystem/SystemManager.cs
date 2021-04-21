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
        private List<Airline> _airlines;
        #endregion

        #region Constructors
        public SystemManager()
        {
            _airports = new List<Airport>();
            _airlines = new List<Airline>();
        }
        #endregion

        #region Properties
        public List<Airport> Airports
        {
            get
            {
                List<Airport> airportsCopy = null;

                if (_airports != null)
                {
                    airportsCopy = new List<Airport>();
                    for (int i = 0; i < _airports.Count; i++)
                    {
                        airportsCopy.Add(new Airport(_airports[i]));
                    }
                }

                return airportsCopy;
            }
        }
        public List<Airline> Airlines 
        { 
            get
            {
                List<Airline> airlinesCopy = null;

                if (_airlines != null)
                {
                    airlinesCopy = new List<Airline>();
                    for (int i = 0; i < _airlines.Count; i++)
                    {
                        airlinesCopy.Add(new Airline(_airlines[i]));
                    }
                }

                return airlinesCopy;
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
        public void CreateAirline(string airlineName)
        {
            if (!DoesAirlineExist(airlineName))
            {
                _airlines.Add(new Airline(airlineName));
            }
            else
            {
                throw new ArgumentException($"Airline {airlineName} already exists!");
            }
        }
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
        private bool DoesAirlineExist(string airlineName)
        {
            bool exists = false;

            foreach (Airline airline in _airlines)
            {
                if (airline.Name == airlineName)
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
