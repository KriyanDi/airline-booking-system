import { AIRPORT } from "../actions/actionTypes";

const initialState = {
  airports: new Map()
    .set(100, { name: "DTC", id: 100 })
    .set(101, { name: "BGN", id: 101 })
    .set(102, { name: "UTS", id: 102 })
    .set(103, { name: "WEQ", id: 103 })
    .set(104, { name: "POS", id: 104 }),
};

export default function airportReducer(state = initialState, action) {
  let airportsCopy = new Map(state.airports);
  let { payload } = action;

  console.log(state);

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
      // delete airport from airports
      airportsCopy.delete(payload.id);

      // delete flights that contain that airport
      let flightsCopy = new Map(state.flights);

      for (let key of flightsCopy.keys()) {
        let tmpFlight = flightsCopy.get(key);
        if (tmpFlight.from === payload.name || tmpFlight.to === payload.name) {
          flightsCopy.delete(key);
        }
      }

      return {
        ...state,
        airports: airportsCopy,
        flights: flightsCopy,
      };
    default:
      return state;
  }
}
