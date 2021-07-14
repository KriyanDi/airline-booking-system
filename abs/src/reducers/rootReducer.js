import { combineReducers } from "redux";

import airportReducer from "./airport";

const rootReducer = combineReducers({
  airportReducer,
});

export default rootReducer;
