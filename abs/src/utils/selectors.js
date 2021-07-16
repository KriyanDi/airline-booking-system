// Returns array of airports from the store
export const selectAirports = (store) =>
  store && store.airportReducer
    ? Array.from(store.airportReducer.airports.values())
    : [];

// Returns array of airlines from the store
export const selectAirlines = (store) =>
  store && store.airlineReducer
    ? Array.from(store.airlineReducer.airlines.values())
    : [];

// Returns array of flights from the store
export const selectFlights = (store) =>
  store && store.flightReducer
    ? Array.from(store.flightReducer.flights.values())
    : [];

// Returns array of flightIds from the store
export const selectFlightIds = (store) =>
  selectFlights(store).map((el) => el.flightId);

// Returns flight by given flightId
export const selectFlightByFlightId = (store, flightId) =>
  selectFlights(store).find((el) => el.flightId === flightId);

// Returns array of seat classes of flight by given flightId
export const selectFlightSeatClasses = (store, id) =>
  selectFlightByFlightId(store, id).seatClasses;
