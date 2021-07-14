export const selectAirportList = (store) =>
  store && store.airportReducer
    ? Array.from(store.airportReducer.airports.values())
    : [];

export const selectAirlineList = (store) =>
  store && store.airlineReducer
    ? Array.from(store.airlineReducer.airlines.values())
    : [];
