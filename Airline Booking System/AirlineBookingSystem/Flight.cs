using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class Flight
    {
        #region Fields
        private FlightInformation _information;
        private List<FlightSection> _flightSections;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse constructor
        /// </summary>
        /// <param name="airlineName"></param>
        /// <param name="originatingAirport"></param>
        /// <param name="destinationAirport"></param>
        /// <param name="flightNumber"></param>
        /// <param name="departureDate"></param>
        public Flight(string airlineName, string originatingAirport, string destinationAirport, int flightNumber, DateTime departureDate)
        {
            string id = null;
            InitializeInformation(airlineName, originatingAirport, destinationAirport, flightNumber, departureDate, id);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Flight(Flight other)
        {
            Information = new FlightInformation(other.Information);
            FlightSections = other.FlightSections;
        }
        #endregion

        #region Properties
        public List<FlightSection> FlightSections
        {
            get
            {
                List<FlightSection> flightSectionsCopy = null;

                if (_flightSections != null)
                {
                    flightSectionsCopy = new List<FlightSection>();
                    for (int i = 0; i < _flightSections.Count; i++)
                    {
                        flightSectionsCopy.Add(new FlightSection(_flightSections[i]));
                    }
                }

                return flightSectionsCopy;
            }

            set
            {
                if (value != null)
                {
                    List<FlightSection> flightSectionsCopy = new List<FlightSection>();
                    for (int i = 0; i < value.Count; i++)
                    {
                        flightSectionsCopy.Add(new FlightSection(value[i]));
                    }

                    _flightSections = flightSectionsCopy;
                }
            }
        }
        public FlightInformation Information
        {
            // Returns a COPY!
            get => new FlightInformation(_information);
            private set => _information = value;
        }
        #endregion

        #region Methods
        public void AddFlightSection(FlightSection section)
        {
            if (_flightSections == null)
            {
                _flightSections = new List<FlightSection>();
                _flightSections.Add(new FlightSection(section));
            }
            else if (!DoFlightSectionsContain(section))
            {
                _flightSections.Add(new FlightSection(section));
            }
            else
            {
                throw new ArgumentException("This flight section already exist! Can store only one of each kind of sections.");
            }
        }
        public void ChangeFlightInformationId(string uniqueId)
        {
            _information.Id = uniqueId;
        }
        #endregion

        #region Help Methods
        private bool DoFlightSectionsContain(FlightSection section)
        {
            bool result = false;

            for (int i = 0; i < _flightSections.Count; i++)
            {
                if (_flightSections[i].SeatClass == section.SeatClass)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        private void InitializeInformation(string airlineName, string originatingAirport, string destinationAirport, int flightNumber, DateTime departureDate, string id)
        {
            if (originatingAirport != destinationAirport)
            {
                Information = new FlightInformation(airlineName, originatingAirport, destinationAirport, flightNumber, departureDate, id);
                        }
            else
            {
                throw new ArgumentException("Originating Airport and Destination Airport can not be the same.");
            }
        }
        #endregion
    }
}
