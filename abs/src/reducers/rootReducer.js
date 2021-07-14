import { combineReducers } from "redux";

import airportReducer from "./airport";
import airlineReducer from "./airline";
import flightReducer from "./flight";

const rootReducer = combineReducers({
  airportReducer,
  airlineReducer,
  flightReducer,
});

export default rootReducer;
