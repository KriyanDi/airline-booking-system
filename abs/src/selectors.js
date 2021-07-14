export const selectAirportList = (store) =>
  store && store.airportReducer
    ? Array.from(store.airportReducer.airports.values())
    : [];
