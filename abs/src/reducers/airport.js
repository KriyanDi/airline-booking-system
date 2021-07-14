import { AIRPORT } from "../actions/actionTypes";

const initialState = {
  airports: new Map(),
};

export default function airportReducer(state = initialState, action) {
  switch (action.type) {
    case AIRPORT.ADD_AIRPORT:
      let copyAirportsAdd = new Map(state.airports).set(action.payload.id, {
        name: action.payload.name,
        id: action.payload.id,
      });
      return {
        ...state,
        airports: copyAirportsAdd,
      };
    case AIRPORT.DELETE_AIRPORT:
      let copyAirportsDelete = new Map(state.airports);
      copyAirportsDelete.delete(action.payload.id);
      return {
        ...state,
        airports: copyAirportsDelete,
      };
    default:
      return state;
  }
}
