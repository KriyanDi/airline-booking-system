import { AIRLINE } from "../actions/actionTypes";

const initialState = {
  airlines: new Map()
    .set(100, { name: "DELTA", id: 100 })
    .set(101, { name: "WIZZA", id: 101 })
    .set(102, { name: "STOXS", id: 102 })
    .set(103, { name: "FLYFL", id: 103 })
    .set(104, { name: "MEGDL", id: 104 }),
};

export default function airlineReducer(state = initialState, action) {
  let airlinesCopy = new Map(state.airlines);
  let { payload } = action;

  switch (action.type) {
    case AIRLINE.ADD_AIRLINE:
      airlinesCopy.set(payload.id, {
        name: payload.name,
        id: payload.id,
      });

      return {
        ...state,
        airlines: airlinesCopy,
      };

    case AIRLINE.DELETE_AIRLINE:
      airlinesCopy.delete(payload.id);

      return {
        ...state,
        airlines: airlinesCopy,
      };
    default:
      return state;
  }
}
