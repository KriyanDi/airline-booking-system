import { combineReducers } from "redux";

import airportsReducer from "../_redux/slices/airportsSlice";
import airlinesReducer from "../_redux/slices/airlinesSlice";
import flightsReducer from "../_redux/slices/flightsSlice";

const rootReducer = combineReducers({
  airportsReducer,
  airlinesReducer,
  flightsReducer,
});

export default rootReducer;
