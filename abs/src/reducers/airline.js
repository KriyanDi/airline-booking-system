import { AIRLINE } from "../actions/actionTypes";

const initialState = {
  airlines: new Map(),
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
