import { AIRPORT } from "../actions/actionTypes";

const initialState = {
  airports: new Map(),
};

export default function airportReducer(state = initialState, action) {
  let airportsCopy = new Map(state.airports);
  let { payload } = action;

  switch (action.type) {
    case AIRPORT.ADD_AIRPORT:
      airportsCopy.set(payload.id, {
        name: payload.name,
        id: payload.id,
      });

      return {
        ...state,
        airports: airportsCopy,
      };

    case AIRPORT.DELETE_AIRPORT:
      airportsCopy.delete(payload.id);

      return {
        ...state,
        airports: airportsCopy,
      };
    default:
      return state;
  }
}
