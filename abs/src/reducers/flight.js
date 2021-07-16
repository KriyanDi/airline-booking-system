import { FLIGHT } from "../actions/actionTypes";

const initialState = {
  flights: new Map(),
};

const setSeats = (rows, cols) => {
  let seats = new Map();

  for (let i = 1; i <= rows; i++) {
    for (let j = 0; j <= cols; j++) {
      seats.set(i + j, { isBooked: false });
    }
  }

  return seats;
};

export default function flightReducer(state = initialState, action) {
  switch (action.type) {
    case FLIGHT.ADD_FLIGHT:
      const { airline, from, to, id } = action.payload;

      let flightId = `${airline}${from}${to}${id}`;
      let copyFlightsAdd = new Map(state.flights).set(id, {
        flightId: flightId,
        id: id,
        airline,
        from,
        to,
        seatClasses: [],
      });
      return {
        ...state,
        flights: copyFlightsAdd,
      };

    case FLIGHT.DELETE_FLIGHT:
      let deleteFlightId = action.payload.id;
      let copyFlightsDelete = new Map(state.flights);

      copyFlightsDelete.delete(deleteFlightId);

      return {
        ...state,
        flights: copyFlightsDelete,
      };

    case FLIGHT.ADD_SECTION:
      let copyFlightsSection = new Map(state.flights);
      let flight = copyFlightsSection.get(action.payload.id);

      console.log("ADD SECTION");
      console.log(flight.seatClasses);
      flight.seatClasses.push({
        id: flight.flightId,
        seatClass: action.payload.seatClass,
        seats: "seats", //fix this
        rows: action.payload.rows,
        cols: action.payload.cols,
        maxCapacity: action.payload.rows * action.payload.cols,
        currentCapacity: 0,
      });

      copyFlightsSection.set(action.payload.id, flight);

      return {
        ...state,
        flights: copyFlightsSection,
      };

    case FLIGHT.DELETE_SECTION:
      let copyFlightsDeleteSection = new Map(state.flights);
      copyFlightsDeleteSection.delete(action.payload.id);
      return {
        ...state,
        flights: copyFlightsDeleteSection,
      };

    case FLIGHT.BOOK_SEAT:
    case FLIGHT.UNBOOK_SEAT:
    default:
      return state;
  }
}
