// import { IAirline } from "../interfaces/airlineModel";
// import { IAirport } from "../interfaces/airportModel";
// import { IFlight, ISeatClasses } from "../interfaces/flightModel";
// import { RootState } from "../_redux/store";

// // Returns array of airports from the state
// export const selectAirports = (state: RootState): IAirport[] =>
//   state && state.airportsReducer ? Array.from(state.airportsReducer.airports.values()) : [];

// // Returns array of airlines from the state
// export const selectAirlines = (state: RootState): IAirline[] =>
//   state && state.airlinesReducer ? Array.from(state.airlinesReducer.airlines.values()) : [];

// // Returns array of flights from the state
// export const selectFlights = (state: RootState): IFlight[] =>
//   state && state.flightsReducer ? Array.from(state.flightsReducer.flights.values()) : [];

// // Returns array of flightIds from the state
// export const selectFlightIds = (state: RootState): string[] => selectFlights(state).map((el: IFlight) => el.flightId);

// // Returns flight by given flightId
// export const selectFlightByFlightId = (state: RootState, flightId: string): IFlight | undefined =>
//   selectFlights(state).find((el: IFlight) => el.flightId === flightId);

// // Returns array of seat classes of flight by given flightId
// export const selectFlightSeatClasses = (state: RootState, flightId: string): Map<string, ISeatClasses> | undefined =>
//   selectFlightByFlightId(state, flightId)?.seatClasses;
export {};