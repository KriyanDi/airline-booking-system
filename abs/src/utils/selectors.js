export const selectAirportList = (store) =>
  store && store.airportReducer
    ? Array.from(store.airportReducer.airports.values())
    : [];

export const selectAirlineList = (store) =>
  store && store.airlineReducer
    ? Array.from(store.airlineReducer.airlines.values())
    : [];

export const selectFlightList = (store) =>
  store && store.flightReducer
    ? Array.from(store.flightReducer.flights.values())
    : [];

export const selectFlightIds = (store) =>
  selectFlightList(store).map((el) => el.flightId);

export const selectFlightByFlightId = (store, flightId) =>
  selectFlightList(store).find((el) => el.flightId === flightId);

export const selectFlightSeatClasses = (store, id) =>
  selectFlightByFlightId(store, id).seatClasses;
