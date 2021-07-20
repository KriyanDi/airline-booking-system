import { AIRLINE, AIRPORT, FLIGHT } from "../actions/actionTypes";

const initialState = {
  flights: new Map(),
};

const setSeats = (rows, cols) => {
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

export default function flightReducer(state = initialState, action) {
  let flightsCopy = new Map(state.flights);
  let flight = {};
  let seatClassCopy = {};
  let seatCopy = {};

  let { payload } = action;

  switch (action.type) {
    case FLIGHT.ADD_FLIGHT:
      // Creates unique flightId
      let flightId = `${payload.airline}${payload.from}${payload.to}${payload.id}`;

      // Adds new flight to the copy of flights from the store
      flightsCopy.set(payload.id, {
        flightId: flightId,
        id: payload.id,
        airline: payload.airline,
        from: payload.from,
        to: payload.to,
        seatClasses: new Map(),
        date: payload.date.toDateString(),
      });

      return {
        ...state,
        flights: flightsCopy,
      };

    case FLIGHT.DELETE_FLIGHT:
      flightsCopy.delete(payload.id);

      return {
        ...state,
        flights: flightsCopy,
      };

    case FLIGHT.ADD_SECTION:
      flight = flightsCopy.get(payload.id);

      flight.seatClasses.set(payload.seatClass, {
        seatClass: payload.seatClass,
        seats: setSeats(payload.rows, payload.cols),
        id: flight.flightId,
        rows: payload.rows,
        cols: payload.cols,
        maxCapacity: payload.rows * payload.cols,
        currentCapacity: 0,
      });

      flightsCopy.set(payload.id, flight);

      return {
        ...state,
        flights: flightsCopy,
      };

    case FLIGHT.DELETE_SECTION:
      flight = flightsCopy.get(payload.id);

      flight.seatClasses.delete(payload.seatClass);

      flightsCopy.set(payload.id, flight);

      return {
        ...state,
        flights: flightsCopy,
      };

    case FLIGHT.BOOK_SEAT:
      flight = flightsCopy.get(payload.id);

      seatClassCopy = flight.seatClasses.get(payload.seatClass);

      seatCopy = seatClassCopy.seats.get(payload.seatId);
      seatCopy = { ...seatCopy, isBooked: true };

      seatClassCopy.seats.set(payload.seatId, seatCopy);

      flight.seatClasses.set(payload.seatClass, seatClassCopy);

      flightsCopy.set(payload.id, flight);

      return {
        ...state,
        flights: flightsCopy,
      };

    case FLIGHT.DELETE_FLIGHTS_ON_DELETED_AIRPORT:
      flightsCopy = new Map(state.flights);

      for (let key of flightsCopy.keys()) {
        let tmpFlight = flightsCopy.get(key);
        if (tmpFlight.from === payload.name || tmpFlight.to === payload.name) {
          flightsCopy.delete(key);
        }
      }

      return {
        ...state,
        flights: flightsCopy,
      };

    case FLIGHT.DELETE_FLIGHTS_ON_DELETED_AIRLINE:
      flightsCopy = new Map(state.flights);

      for (let key of flightsCopy.keys()) {
        let tmpFlight = flightsCopy.get(key);
        if (tmpFlight.airline === payload.name) {
          flightsCopy.delete(key);
        }
      }

      return {
        ...state,
        flights: flightsCopy,
      };

    case FLIGHT.UNBOOK_SEAT:

    default:
      return state;
  }
}
