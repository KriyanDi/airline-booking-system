import { Action, AIRPORT } from "../interfaces/actionTypes";

const initialState = {
  airports: new Map()
    .set(100, { name: "DTC", id: 100 })
    .set(101, { name: "BGN", id: 101 })
    .set(102, { name: "UTS", id: 102 })
    .set(103, { name: "WEQ", id: 103 })
    .set(104, { name: "POS", id: 104 }),
};

export default function airportReducer(
  state: typeof initialState = initialState,
  action: Action<AIRPORT, any>
) {
  let airportsCopy = new Map(state.airports);
  let { payload } = action;

  switch (action.type) {
    case "ADD_AIRPORT":
      airportsCopy.set(payload.id, {
        name: payload.name,
        id: payload.id,
      });

      return {
        ...state,
        airports: airportsCopy,
      };

    case "DELETE_AIRPORT":
      airportsCopy.delete(payload.id);

      return {
        ...state,
        airports: airportsCopy,
      };
    default:
      return state;
  }
}
