import { FLIGHT } from "../actions/actionTypes";

const initialState = {
  flights: new Map(),
};

// const setSeats = (rows, cols) => {
//   let seats = new Map();

//   for (let i = 1; i <= rows; i++) {
//     for (let j = 0; j <= cols; j++) {
//       seats.set(i + j, { isBooked: false });
//     }
//   }

//   return seats;
// };

export default function flightReducer(state = initialState, action) {
  let flightsCopy = new Map(state.flights);
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
        seatClasses: [],
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
      let flight = flightsCopy.get(payload.id);

      flight.seatClasses.push({
        id: flight.flightId,
        seatClass: payload.seatClass,
        seats: "seats", //fix this
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
    case FLIGHT.BOOK_SEAT:
    case FLIGHT.UNBOOK_SEAT:
    default:
      return state;
  }
}
