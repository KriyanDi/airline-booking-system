import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IFlight } from "../../interfaces/flightModel";

let counter = 0;

const setSeats = (rows: number, cols: number) => {
  let seats = new Map();

  for (let i = 0; i < rows; i++) {
    for (let j = 0; j < cols; j++) {
      seats.set(`${i + 1}${String.fromCharCode(65 + j)}`, {
        seat: `${i + 1} ${String.fromCharCode(65 + j)}`,
        isBooked: "false",
      });
    }
  }

  return seats;
};

export interface FlightState {
  flights: Map<number, IFlight>;
}

const initialState: FlightState = {
  flights: new Map(),
};

export const flightsSlice = createSlice({
  name: ":flights",
  initialState: initialState,
  reducers: {
    createFlight: (
      state,
      action: PayloadAction<{
        airline: string;
        from: string;
        to: string;
        date: Date;
      }>
    ) => {
      let { payload } = action;
      let id = counter++;

      // Creates unique flightId
      let flightId = `${payload.airline}${payload.from}${payload.to}${id}`;

      // Adds new flight to the copy of flights from the store
      state.flights.set(id, {
        flightId: flightId,
        id: id,
        airline: payload.airline,
        from: payload.from,
        to: payload.to,
        seatClasses: new Map(),
        date: payload.date,
      });

      return state;
    },

    deleteFlight: (state, action: PayloadAction<{ id: number }>) => {
      state.flights.delete(action.payload.id);

      return state;
    },

    deleteFlightsOnDeletedAirport: (state, action: PayloadAction<{ name: string }>) => {
      let { payload } = action;

      for (let key in state.flights.keys()) {
        let flight = state.flights.get(parseInt(key));
        if (flight!.from === payload.name || flight!.to === payload.name) {
          state.flights.delete(parseInt(key));
        }
      }

      return state;
    },

    deleteFlightsOnDeletedAirline: (state, action: PayloadAction<{ name: string }>) => {
      let { payload } = action;

      for (let key in state.flights.keys()) {
        let flight = state.flights.get(parseInt(key));
        if (flight!.airline === payload.name) {
          state.flights.delete(parseInt(key));
        }
      }

      return state;
    },

    createSection: (state, action: PayloadAction<{ id: number; seatClass: string; rows: number; cols: number }>) => {
      let { payload } = action;

      let flight = state.flights.get(payload.id);

      if (flight?.seatClasses !== undefined) {
        flight.seatClasses.set(payload.seatClass, {
          seatClass: payload.seatClass,
          seats: setSeats(payload.rows, payload.cols),
          rows: payload.rows,
          cols: payload.cols,
          maxCapacity: payload.rows * payload.cols,
          currOcuppation: 0,
        });

        state.flights.set(payload.id, flight);
      }

      return state;
    },

    deleteSection: (state, action: PayloadAction<{ id: number; seatClass: string }>) => {
      let { payload } = action;

      let flight = state.flights.get(payload.id);

      if (flight?.seatClasses !== undefined) {
        flight.seatClasses.delete(payload.seatClass);

        state.flights.set(payload.id, flight);
      }

      return state;
    },

    bookSeat: (state, action: PayloadAction<{ id: number; seatClass: string; seatId: string }>) => {
      let { payload } = action;

      let flight = state.flights.get(payload.id);
      let seatClass = flight?.seatClasses.get(payload.seatClass);
      let seat = seatClass!.seats!.get(payload.seatId);

      if (seat?.isBooked === false && seatClass !== undefined && flight !== undefined) {
        seat = { ...seat, isBooked: true };

        seatClass.seats!.set(payload.seatId, seat);

        seatClass.currOcuppation++;

        flight.seatClasses.set(payload.seatClass, seatClass);

        state.flights.set(payload.id, flight);
      }

      return state;
    },
  },
});

export const {
  createFlight,
  deleteFlight,
  deleteFlightsOnDeletedAirport,
  deleteFlightsOnDeletedAirline,
  createSection,
  deleteSection,
  bookSeat,
} = flightsSlice.actions;

export default flightsSlice.reducer;
