using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class Airline
    {
        #region Fields
        private string _name;
        private List<Flight> _flights;
        private static int flightsCounter;
        #endregion

        #region Constructors
        static Airline()
        {
            flightsCounter = 0;
        }
        public Airline(string name)
        {
            Name = name;
        }
        public Airline(Airline other) : this(other.Name)
        {
        }
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                if (value != null)
                {
                    if (value.HasLengthMoreThanOneAndLessThanSix())
                    {
                        if (value.HasOnlyCapitalLettersAndNumbers())
                        {
                            _name = value;
                        }
                        else
                        {
                            throw new ArgumentException("Airline name should contain only capital letters and numbers.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Airline name should be between 1 and 5 symbols long.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Airline name can not be null.");
                }
            }
        }
        public List<Flight> Flights
        {
            get
            {
                List<Flight> flightsCopy = null;

                if (_flights != null)
                {
                    flightsCopy = new List<Flight>();
                    for (int i = 0; i < _flights.Count; i++)
                    {
                        flightsCopy.Add(new Flight(_flights[i]));
                    }
                }

                return flightsCopy;
            }

            set
            {
                List<Flight> flightsCopy = null;

                if (value != null)
                {
                    flightsCopy = new List<Flight>();
                    for (int i = 0; i < value.Count; i++)
                    {
                        flightsCopy.Add(new Flight(value[i]));
                    }
                }

                _flights = flightsCopy;
            }
        }
        #endregion

        #region Methods
        public bool AddFlight(Flight flight)
        {
            flightsCounter += 1;

            Flight flightCopy = new Flight(flight);
            flightCopy.ChangeFlightInformationId($"{Name}{flightsCounter:D5}");

            if (_flights == null)
            {
                _flights = new List<Flight>();
            }

            _flights.Add(new Flight(flightCopy));
            Console.WriteLine($"{Name}");
            return true;
        }
        #endregion
    }
}
