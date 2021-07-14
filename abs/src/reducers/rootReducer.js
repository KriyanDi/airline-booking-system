import { combineReducers } from "redux";

import airportReducer from "./airport";
import airlineReducer from "./airline";

const rootReducer = combineReducers({
  airportReducer,
  airlineReducer,
});

export default rootReducer;
