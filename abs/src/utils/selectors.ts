// Returns array of airports from the store
export const selectAirports = (store: any) =>
  store && store.airportReducer ? Array.from(store.airportReducer.airports.values()) : [];

// Returns array of airlines from the store
export const selectAirlines = (store: any) =>
  store && store.airlineReducer ? Array.from(store.airlineReducer.airlines.values()) : [];

// Returns array of flights from the store
export const selectFlights = (store: any) =>
  store && store.flightReducer ? Array.from(store.flightReducer.flights.values()) : [];

// Returns array of flightIds from the store
export const selectFlightIds = (store: any) => selectFlights(store).map((el: any) => el.flightId);

// Returns flight by given flightId
export const selectFlightByFlightId = (store: any, flightId: any): any =>
  selectFlights(store).find((el: any) => el.flightId === flightId);

// Returns array of seat classes of flight by given flightId
export const selectFlightSeatClasses = (store: any, flightId: any): any =>
  selectFlightByFlightId(store, flightId).seatClasses;
