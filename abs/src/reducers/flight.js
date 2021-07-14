import { FLIGHT } from "../actions/actionTypes";

const initialState = {
  flights: new Map(),
};

const setSeats = (rows, cols) => {
  let seats = new Map();

  for (let i = 1; i <= rows; i++) {
    for (let j = 0; j < cols; j++) {
      seats.set(i + j, { isBooked: false });
    }
  }

  return seats;
};

export default function flightReducer(state, action) {
  switch (action.type) {
    case FLIGHT.ADD_FLIGHT:
      const { airline, from, to, seatClass, id } = action.payload;

      let flightId = `${airline}${from}${to}${id}`;
      let copyFlightsAdd = new Map(state.flights).set(id, {
        airline,
        from,
        to,
        seatClasses: [],
        id: flightId,
      });
      return {
        ...state,
        flights: copyFlightsAdd,
      };

    case FLIGHT.DELETE_FLIGHT:
      let deleteFlightId = action.payload.id;
      let copyFlightsDelete = new Map(state.flights);
      return {
        ...state,
        flights: copyFlightsDelete,
      };

    case FLIGHT.ADD_SECTION:
      let copyFlightsSection = new Map(state.flights);
      let addSectionTo = copyFlightsSection.get(action.payload.id);
      addSectionTo = {
        ...addSectionTo,
        seatClasses: [
          ...addSectionTo.seatClasses,
          {
            seatClass: action.payload.seatClass,
            seats: setSeats(action.payload.rows, action.payload.cols),
            rows: action.payload.rows,
            cols: action.payload.cols,
            maxCapacity: rows * cols,
            currentCapacity: 0,
          },
        ],
      };
      copyFlightsSection.set(action.payload.id, addSectionTo);
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
    
    case: FLIGHT.BOOK_SEAT:
    case: FLIGHT.UNBOOK_SEAT:
    default: return state;
  }
}
