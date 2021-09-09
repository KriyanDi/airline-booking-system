import { configureStore } from "@reduxjs/toolkit";
import airportReducer from "./slices/airport/airportSlice";
import airlineReducer from "./slices/airline/airlineSlice";
import flightReducer from "./slices/flight/flightSlice";
import userReducer from "./slices/user/userSlice";

const store = configureStore({
  reducer: {
    airportReducer,
    airlineReducer,
    flightReducer,
    userReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;

export default store;
