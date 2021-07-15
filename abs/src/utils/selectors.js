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

export const selectFlightById = (store, id) =>
  selectAirlineList(store).Find((el) => el.id === id);

export const selectFlightSeatClasses = (store, id) =>
  selectFlightById(store, id).seatClasses;
