import { Action, FLIGHT } from "../interfaces/actionTypes";
import { IFlight, ISeat, ISeatClasses } from "../interfaces/flightModel";

const initialState = {
  flights: new Map(),
};

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

export default function flightReducer(
  state: typeof initialState = initialState,
  action: Action<FLIGHT, any>
) {
  let flightsCopy = new Map(state.flights);
  let flight: IFlight = {};
  let seatClassCopy: ISeatClasses = {};
  let seatCopy: ISeat = {};

  let { payload } = action;

  switch (action.type) {
    case "ADD_FLIGHT":
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

    case "DELETE_FLIGHT":
      flightsCopy.delete(payload.id);

      return {
        ...state,
        flights: flightsCopy,
      };

    case "ADD_SECTION":
      flight = flightsCopy.get(payload.id);

      if (flight.seatClasses !== undefined) {
        flight.seatClasses.set(payload.seatClass, {
          seatClass: payload.seatClass,
          seats: setSeats(payload.rows, payload.cols),
          rows: payload.rows,
          cols: payload.cols,
          maxCapacity: payload.rows * payload.cols,
          currOcuppation: 0,
        });
      }

      flightsCopy.set(payload.id, flight);

      return {
        ...state,
        flights: flightsCopy,
      };

    case "DELETE_SECTION":
      flight = flightsCopy.get(payload.id);

      if (flight.seatClasses !== undefined) {
        flight.seatClasses.delete(payload.seatClass);
      }

      flightsCopy.set(payload.id, flight);

      return {
        ...state,
        flights: flightsCopy,
      };

    case "DELETE_FLIGHTS_ON_DELETED_AIRPORT":
      flightsCopy = new Map(state.flights);

      for (let key in flightsCopy.keys()) {
        let tmpFlight = flightsCopy.get(key);
        if (tmpFlight.from === payload.name || tmpFlight.to === payload.name) {
          flightsCopy.delete(key);
        }
      }

      return {
        ...state,
        flights: flightsCopy,
      };

    case "DELETE_FLIGHTS_ON_DELETED_AIRLINE":
      flightsCopy = new Map(state.flights);

      for (let key in flightsCopy.keys()) {
        let tmpFlight = flightsCopy.get(key);
        if (tmpFlight.airline === payload.name) {
          flightsCopy.delete(key);
        }
      }

      return {
        ...state,
        flights: flightsCopy,
      };

    case "BOOK_SEAT":
      flight = flightsCopy.get(payload.id);

      seatClassCopy = flight.seatClasses!.get(payload.seatClass)!;

      seatCopy = seatClassCopy.seats!.get(payload.seatId)!;

      if (seatCopy.isBooked === false) {
        seatCopy = { ...seatCopy, isBooked: true };

        seatClassCopy.seats!.set(payload.seatId, seatCopy);

        seatClassCopy.currOcuppation!++;

        flight.seatClasses!.set(payload.seatClass, seatClassCopy);

        flightsCopy.set(payload.id, flight);
      }

      return {
        ...state,
        flights: flightsCopy,
      };

    default:
      return state;
  }
}
