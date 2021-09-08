import { configureStore } from "@reduxjs/toolkit";
import airportReducer from "./slices/airport/airportSlice";

const store = configureStore({
  reducer: {
    airportReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;

export default store;
