import { AIRLINE } from "../actions/actionTypes";

const initialState = {
  airlines: new Map(),
};

export default function airlineReducer(state = initialState, action) {
  switch (action.type) {
    case AIRLINE.ADD_AIRLINE:
      let copyAirlinesAdd = new Map(state.airlines).set(action.payload.id, {
        id: action.payload.id,
        name: action.payload.name,
      });
      return {
        ...state,
        airlines: copyAirlinesAdd,
      };
    case AIRLINE.DELETE_AIRLINE:
      let copyAirlinesDelete = new Map(state.airlines);
      copyAirlinesDelete.delete(action.payload.id);
      return {
        ...state,
        airlines: copyAirlinesDelete,
      };
    default:
      return state;
  }
}
